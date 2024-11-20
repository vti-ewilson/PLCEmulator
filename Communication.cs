﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Xml;
using System.Windows.Forms;

namespace PLCEmulator
{
	class DigitalInputOutput : ICloneable
	{
		public DigitalInputOutput(int address, string name, bool value)
		{
			this.address = address;
			this.number = getNumberFromAddress(address);
			this.name = name;
			this.value = value;
		}

		public static int getNumberFromAddress(int address)
		{
			int a = address / 16;
			int b = a * 50;
			return b + address - (a * 16) + 1;
		}

		public object Clone()
		{
			return new DigitalInputOutput(address, name, value);
		}

		public int address;
		public int number;
		public string name;
		public bool value;
	}

	class AnalogInput
	{
		public AnalogInput(int address, string name, Single value)
		{
			this.address = address;
			this.channel = getChannelFromAddress(address);
			this.name = name;
			this.value = value;
		}

		public static int getChannelFromAddress(int address)
		{
			return (address / 2) + 1;
		}

		public int address;
		public int channel;
		public string name;
		public Single value;
	}

	class IO
	{
		public static SortedDictionary<int, List<DigitalInputOutput>> outputs = new SortedDictionary<int, List<DigitalInputOutput>>(); //(address, List of outputs at address)
		public static SortedDictionary<int, List<DigitalInputOutput>> inputs = new SortedDictionary<int, List<DigitalInputOutput>>(); //(address, List of outputs at address)
		public static SortedDictionary<int, AnalogInput> analogInputs = new SortedDictionary<int, AnalogInput>(); //(address, List of outputs at address)
		public static Mutex outputMutex = new Mutex();
		public static Mutex inputMutex = new Mutex();
		public static Mutex analogInputMutex = new Mutex();
	}

	internal class Communication
	{
		public static bool closeSocket = false;
		public static void ExecuteServer()
		{
			IPHostEntry ipHost = Dns.GetHostEntry("127.0.0.1");
			IPAddress ipAddr = ipHost.AddressList[0];
			IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 502);

			Socket listener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

			listener.Bind(localEndPoint);

			listener.Listen(10);

			while(true) 
			{

				Console.WriteLine("Waiting connection ... ");

				Socket clientSocket = listener.Accept();

				try
				{
					while(!closeSocket)
					{
						// Data buffer
						byte[] bytes = new Byte[1024];
						byte[] response = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

						int numByte = clientSocket.Receive(bytes);
						int address = bytes[9];

						if(bytes[7] == 15) // reading digital outputs
						{
							int outputNumber = DigitalInputOutput.getNumberFromAddress(address);
							bool value;
							List<DigitalInputOutput> outputsAtAddress = new List<DigitalInputOutput>();

							// store output values in list
							for(int i = 0; i < 8; i++)
							{
								value = ((bytes[13] >> i) & 1) > 0;
								outputsAtAddress.Add(new DigitalInputOutput(address, address.ToString(), value));
							}

							IO.outputMutex.WaitOne();
							if(!IO.outputs.ContainsKey(outputNumber))
							{
								IO.outputs.Add(outputNumber, outputsAtAddress); // Add new outputs
							}
							else
							{
								IO.outputs[outputNumber] = outputsAtAddress; // Update existing outputs
							}
							IO.outputMutex.ReleaseMutex();
						}
						else if(bytes[7] == 2) // setting digital inputs
						{
							List<DigitalInputOutput> inputsAtAddress = new List<DigitalInputOutput>(8);
							int inputNumber = DigitalInputOutput.getNumberFromAddress(address);

							IO.inputMutex.WaitOne();
							if(!IO.inputs.ContainsKey(inputNumber))
							{
								inputsAtAddress = new List<DigitalInputOutput>(8);
								for(int i = 0; i < 8; i++)
									inputsAtAddress.Add(new DigitalInputOutput(address, address.ToString(), false));
								IO.inputs.Add(inputNumber, inputsAtAddress);
							}
							else
							{
								inputsAtAddress = IO.inputs[inputNumber];
							}

							// Set response bit for each input
							for(int i = 0; i < inputsAtAddress.Count; i++)
							{
								if(inputsAtAddress[i].value)
									response[9] |= (byte)(1 << i);
							}
							IO.inputMutex.ReleaseMutex();
						}
						else if(bytes[7] == 3)
						{
							response = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
							address = (int)bytes[9];
							int channel = AnalogInput.getChannelFromAddress(address);

							IO.analogInputMutex.WaitOne();
							if(!IO.analogInputs.ContainsKey(channel))
							{
								IO.analogInputs.Add(channel, new AnalogInput(address, "Channel " + channel.ToString(), 0.0f));
							}

							byte[] inputValue = BitConverter.GetBytes(IO.analogInputs[channel].value);
							response[9] = inputValue[1];
							response[10] = inputValue[0];
							response[11] = inputValue[3];
							response[12] = inputValue[2];
							IO.analogInputMutex.ReleaseMutex();

							Console.WriteLine("addr -> {0} ", address);

						}

						string str = BitConverter.ToString(bytes, 0, numByte);
						Console.WriteLine("Text received -> {0} ", str);


						clientSocket.Send(response);
					}
				}
				catch(Exception ex)
				{

				}
				clientSocket.Shutdown(SocketShutdown.Both);
				clientSocket.Close();

				if(Application.OpenForms.Count == 0) break;
			}
		}
	}
}
