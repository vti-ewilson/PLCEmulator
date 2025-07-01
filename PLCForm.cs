using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PLCEmulator
{
	public partial class PLCForm : Form
	{
		private SortedSet<int> outputRows = new SortedSet<int>();
		private SortedSet<int> inputRows = new SortedSet<int>();
		private SortedSet<int> addedAnalogInputs = new SortedSet<int>();
		private SortedSet<int> addedAnalogOutputs = new SortedSet<int>();
		private SortedDictionary<int, TextBox> analogInputTextBoxes = new SortedDictionary<int, TextBox>();
		private SortedDictionary<int, TextBox> analogOutputTextBoxes = new SortedDictionary<int, TextBox>();
		private SortedDictionary<int, List<DigitalInputOutput>> outputsCopy = new SortedDictionary<int, List<DigitalInputOutput>>();
		private List<Label> analogInputLabels = new List<Label>();
		private List<Label> analogOutputLabels = new List<Label>();
		private SortedDictionary<int, TrackBar> trackBars = new SortedDictionary<int, TrackBar>();
		public PLCForm()
		{
			InitializeComponent();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\source\\repos";
			openFileDialog1.RestoreDirectory = true;
		}

		// Make copy of outputs dict to release mutex faster
		private void copyOutputs()
		{
			foreach(var item in IO.outputs)
			{
				var listCopy = new List<DigitalInputOutput>(item.Value.Count);
				foreach(var output in item.Value)
					listCopy.Add((DigitalInputOutput)output.Clone());

				if(!outputsCopy.ContainsKey(item.Key))
				{
					outputsCopy.Add(item.Key, listCopy);
				}
				else
				{
					outputsCopy[item.Key] = listCopy;
				}
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			#region handling outputs
			IO.outputMutex.WaitOne();
			copyOutputs();
			IO.outputMutex.ReleaseMutex();

			foreach(var output in outputsCopy)
			{
				//Create row in table if it doesn't exist
				if(!outputRows.Contains(output.Key))
				{
					int ind = outputGrid.Rows.Add();
					outputGrid.Rows[ind].Cells[Address.Index].Value = output.Key.ToString("000"); // set address cell
					outputGrid.Rows[ind].Cells[Y.Index].Value = "Y"; // set Y cell
					outputRows.Add(output.Key);
				}
			}

			foreach(DataGridViewRow row in outputGrid.Rows)
			{
				int outputKey = Int32.Parse((string)row.Cells[Address.Index].Value);
				if(outputsCopy.ContainsKey(outputKey))
				{
					for(int i = 2; i < row.Cells.Count; i++)
					{
						if(!outputsCopy[outputKey][i - 2].value)
						{
							row.Cells[i].Value = false;
						}
						else if(outputsCopy[outputKey][i - 2].value)
						{
							row.Cells[i].Value = true;
						}
					}
				}
			}
			#endregion

			#region handling inputs

			IO.inputMutex.WaitOne();
			foreach(var input in IO.inputs)
			{
				if(!inputRows.Contains(input.Key))
				{
					int ind = inputGrid.Rows.Add(input);
					inputGrid.Rows[ind].Cells[Address.Index].Value = input.Key.ToString("000");
					inputGrid.Rows[ind].Cells[X.Index].Value = "X"; // set X cell
					inputRows.Add(input.Key);
				}
			}
			IO.inputMutex.ReleaseMutex();

			#endregion

			#region handling analog inputs
			IO.analogInputMutex.WaitOne();
			foreach(var input in IO.analogInputs)
			{
				if(!addedAnalogInputs.Contains(input.Key))
				{
					addedAnalogInputs.Add(input.Key);
					int ind = addedAnalogInputs.Count - 1;

					#region set label properties

					analogInputLabels.Add(new Label());
					analogInputPanel.Controls.Add(analogInputLabels[ind]);
					analogInputLabels[ind].Location = new Point(30, 130 * ind);
					analogInputLabels[ind].Size = new Size(analogInputPanel.Width - 60, 40);
					analogInputLabels[ind].AutoSize = false;
					analogInputLabels[ind].Text = input.Value.name;
					analogInputLabels[ind].Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
					analogInputLabels[ind].ForeColor = SystemColors.ControlLight;
					analogInputLabels[ind].BackColor = Color.Transparent;
					analogInputLabels[ind].Name = "inputLabel" + ind.ToString();
					analogInputLabels[ind].TabIndex = 2*ind;
					analogInputLabels[ind].TextAlign = ContentAlignment.MiddleLeft;

					#endregion

					TextBox box = new TextBox();
					analogInputTextBoxes.Add(input.Key, box);
					analogInputPanel.Controls.Add(box);
					box.BackColor = SystemColors.ControlDarkDark;
					box.BorderStyle = BorderStyle.FixedSingle;
					box.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
					box.ForeColor = SystemColors.Control;
					box.Location = new Point(analogInputPanel.Width - 200, (130 * ind)+5);
					box.Name = "textBox1";
					box.Size = new Size(80, 35);
					box.TabIndex = 10;
					box.Text = "0.000";
					box.TextAlign = HorizontalAlignment.Right;
					box.BringToFront();

					Button setButton = new Button();
					analogInputPanel.Controls.Add(setButton);
					setButton.BackColor = SystemColors.Control;
					setButton.Location = new Point(analogInputPanel.Width - 100, (130 * ind) + 5);
					setButton.Name = "button1";
					setButton.Size = new Size(80, 35);
					setButton.TabIndex = 12;
					setButton.Text = "Set";
					setButton.Tag = input.Key;
					setButton.UseVisualStyleBackColor = false;
					setButton.BringToFront();
					setButton.Click += setButton_Click;

					#region set trackbar properties

					TrackBar trackBar = new TrackBar();
					trackBars.Add(input.Key, trackBar);
					analogInputPanel.Controls.Add(trackBar);
					trackBar.Location = new Point(33, (130 * ind) + 40);
					trackBar.Tag = input.Key;
					trackBar.Size = new Size(648, 70);
					trackBar.TabIndex = 2*ind + 1;
					trackBar.Maximum = 1000;
					trackBar.Minimum = 0;
					trackBar.TickFrequency = 1;
					trackBar.TickStyle = TickStyle.None;
					trackBar.Scroll += trackBar_Scroll;

					#endregion
				}
			}
			IO.analogInputMutex.ReleaseMutex();
			#endregion

			#region handling analog outputs
			IO.analogOutputMutex.WaitOne();
			foreach(var output in IO.analogOutputs)
			{
				if(!addedAnalogOutputs.Contains(output.Key))
				{
					addedAnalogOutputs.Add(output.Key);
					int ind = addedAnalogOutputs.Count - 1;

					#region set label properties

					analogOutputLabels.Add(new Label());
					analogOutputPanel.Controls.Add(analogOutputLabels[ind]);
					analogOutputLabels[ind].Location = new Point(30, 130 * ind);
					analogOutputLabels[ind].Size = new Size(analogOutputPanel.Width - 60, 40);
					analogOutputLabels[ind].AutoSize = false;
					analogOutputLabels[ind].Text = output.Value.name;
					analogOutputLabels[ind].Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
					analogOutputLabels[ind].ForeColor = SystemColors.ControlLight;
					analogOutputLabels[ind].BackColor = Color.Transparent;
					analogOutputLabels[ind].Name = "inputLabel" + ind.ToString();
					analogOutputLabels[ind].TabIndex = 2 * ind;
					analogOutputLabels[ind].TextAlign = ContentAlignment.MiddleLeft;

					#endregion

					TextBox box = new TextBox();
					analogOutputTextBoxes.Add(output.Key, box);
					analogOutputPanel.Controls.Add(box);
					box.BackColor = SystemColors.ControlDarkDark;
					box.BorderStyle = BorderStyle.FixedSingle;
					box.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
					box.ForeColor = SystemColors.Control;
					box.Location = new Point(analogOutputPanel.Width - 200, (130 * ind) + 5);
					box.Name = "textBox1";
					box.Size = new Size(80, 35);
					box.TabIndex = 10;
					box.Text = "0.000";
					box.TextAlign = HorizontalAlignment.Right;
					box.BringToFront();
				}
			}
			IO.analogOutputMutex.ReleaseMutex();
			#endregion
		}

		private void setButton_Click(object sender, EventArgs e)
		{
			double value;
			Button button = (Button)sender;
			int channel = (int)button.Tag;
			if(Double.TryParse(analogInputTextBoxes[channel].Text, out value))
			{
				IO.analogInputMutex.WaitOne();
				IO.analogInputs[channel].value = (float)value;
				IO.analogInputMutex.ReleaseMutex();

				trackBars[channel].Value = (int)(value * 100);
			}
		}

		private void trackBar_Scroll(object sender, EventArgs e)
		{
			TrackBar trackBar = (TrackBar)sender;
			int channel = (int)trackBar.Tag;

			IO.analogInputMutex.WaitOne();
			IO.analogInputs[channel].value = (float)trackBar.Value / 100;
			IO.analogInputMutex.ReleaseMutex();

			analogInputTextBoxes[channel].Text = ((double)trackBar.Value / 100).ToString("0.000");
		}

		private void inputGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if(e.RowIndex < 0 || e.ColumnIndex < 2) return;
			int inputNumber = Int32.Parse((string)inputGrid.Rows[e.RowIndex].Cells[Address.Index].Value);

			IO.inputMutex.WaitOne();
			IO.inputs[inputNumber][e.ColumnIndex - 2].value = (bool)inputGrid[e.ColumnIndex, e.RowIndex].Value; // update value of changed input
			IO.inputMutex.ReleaseMutex();
		}

		private void inputGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if(inputGrid.CurrentCell is DataGridViewCheckBoxCell)
			{
				inputGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
			}
		}

		private void inputGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			int size = 5;
			foreach(DataGridViewColumn col in inputGrid.Columns)
			{
				size += col.Width;
			}
			if(inputGrid.Controls.OfType<VScrollBar>().First().Visible)
			{
				size += SystemInformation.VerticalScrollBarWidth;
			}
			inputPanel.Width = size + inputPanel.Padding.Right + inputPanel.Padding.Left;
		}

		private void outputGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			int size = 5;
			foreach(DataGridViewColumn col in outputGrid.Columns)
			{
				size += col.Width;
			}
			if(outputGrid.Controls.OfType<VScrollBar>().First().Visible)
			{
				size += SystemInformation.VerticalScrollBarWidth;
			}
			outputPanel.Width = size + outputPanel.Padding.Right + outputPanel.Padding.Left;
		}

		private void PLCForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Communication.closeSocket = true;
			Communication.listener.Close();
		}

		private void configSelectButton_Click(object sender, EventArgs e)
		{
			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				configSelectButton.Visible = false;
				//Get the path of specified file
				string filePath = openFileDialog1.FileName;

				//Read the contents of the file into a stream
				var fileStream = openFileDialog1.OpenFile();
				string fileFolder = Directory.GetParent(filePath).Name;

				try
				{
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(MccConfig));
					MccConfig mcc = (MccConfig)xmlSerializer.Deserialize(fileStream);
					AnalogInputs inputs = mcc.AnalogBoards.AnalogBoard.AnalogInputs;
					for(int i = 1; i < inputs.AnalogChannel.Count; i++) // skip ipaddress input
					{
						// Find the label whose Text is "channel " + inputs.AnalogChannel[i].Channel and set its Text to the Name
						string searchText = "Channel " + inputs.AnalogChannel[i].Channel;
						int labelIndex = analogInputLabels.FindIndex(lbl => lbl.Text == searchText);
						if(labelIndex != -1)
						{
							analogInputLabels[labelIndex].Text = inputs.AnalogChannel[i].Name;
						}
					}
					folderNameLabel.Text = fileFolder;
					folderNameLabel.ForeColor = Color.White;
				}
				catch(Exception ex)
				{
					folderNameLabel.Text = "XML Parse Error";
					folderNameLabel.ForeColor = Color.Red;
					Console.WriteLine(ex.ToString());
				}
			}
		}
	}
}

