using System.Collections.Generic;
using System.Xml.Serialization;

namespace PLCEmulator
{
	// using System.Xml.Serialization;
	// XmlSerializer serializer = new XmlSerializer(typeof(MccConfig));
	// using (StringReader reader = new StringReader(xml))
	// {
	//    var test = (MccConfig)serializer.Deserialize(reader);
	// }

	[XmlRoot(ElementName = "DigitalPortBit")]
	public class DigitalPortBit
	{

		[XmlElement(ElementName = "Name")]
		public string Name { get; set; }

		[XmlElement(ElementName = "Description")]
		public string Description { get; set; }

		[XmlElement(ElementName = "Bit")]
		public int Bit { get; set; }
	}

	[XmlRoot(ElementName = "DigitalPortBits")]
	public class DigitalPortBits
	{

		[XmlElement(ElementName = "DigitalPortBit")]
		public List<DigitalPortBit> DigitalPortBit { get; set; }
	}

	[XmlRoot(ElementName = "DigitalPort")]
	public class DigitalPort
	{

		[XmlElement(ElementName = "DigitalPortType")]
		public string DigitalPortType { get; set; }

		[XmlElement(ElementName = "DigitalPortDirection")]
		public string DigitalPortDirection { get; set; }

		[XmlElement(ElementName = "DigitalPortBits")]
		public DigitalPortBits DigitalPortBits { get; set; }
	}

	[XmlRoot(ElementName = "DigitalPorts")]
	public class DigitalPorts
	{

		[XmlElement(ElementName = "DigitalPort")]
		public List<DigitalPort> DigitalPort { get; set; }
	}

	[XmlRoot(ElementName = "DigitalBoard")]
	public class DigitalBoard
	{

		[XmlElement(ElementName = "BoardNum")]
		public int BoardNum { get; set; }

		[XmlElement(ElementName = "InvertedLogic")]
		public bool InvertedLogic { get; set; }

		[XmlElement(ElementName = "DigitalPorts")]
		public DigitalPorts DigitalPorts { get; set; }
	}

	[XmlRoot(ElementName = "DigitalBoards")]
	public class DigitalBoards
	{

		[XmlElement(ElementName = "DigitalBoard")]
		public DigitalBoard DigitalBoard { get; set; }
	}

	[XmlRoot(ElementName = "AnalogChannel")]
	public class AnalogChannel
	{

		[XmlElement(ElementName = "Name")]
		public string Name { get; set; }

		[XmlElement(ElementName = "Channel")]
		public int Channel { get; set; }

		[XmlElement(ElementName = "NumberOfSamples")]
		public int NumberOfSamples { get; set; }

		[XmlElement(ElementName = "NumberOfMovingAverages")]
		public int NumberOfMovingAverages { get; set; }

		[XmlElement(ElementName = "Range")]
		public string Range { get; set; }
	}

	[XmlRoot(ElementName = "AnalogInputs")]
	public class AnalogInputs
	{

		[XmlElement(ElementName = "AnalogChannel")]
		public List<AnalogChannel> AnalogChannel { get; set; }
	}

	[XmlRoot(ElementName = "AnalogBoard")]
	public class AnalogBoard
	{

		[XmlElement(ElementName = "BoardNum")]
		public int BoardNum { get; set; }

		[XmlElement(ElementName = "NumberOfBits")]
		public int NumberOfBits { get; set; }

		[XmlElement(ElementName = "AnalogInputs")]
		public AnalogInputs AnalogInputs { get; set; }
	}

	[XmlRoot(ElementName = "AnalogBoards")]
	public class AnalogBoards
	{

		[XmlElement(ElementName = "AnalogBoard")]
		public AnalogBoard AnalogBoard { get; set; }
	}

	[XmlRoot(ElementName = "MccConfig")]
	public class MccConfig
	{

		[XmlElement(ElementName = "DigitalBoards")]
		public DigitalBoards DigitalBoards { get; set; }

		[XmlElement(ElementName = "AnalogBoards")]
		public AnalogBoards AnalogBoards { get; set; }
	}
}
