using System;
using System.Xml.Serialization;

namespace InloaderXmlXmls.Xml.Model
{

	[Serializable]
	public class Data
	{

		#region Properties

		[XmlAttribute("СинтСчёт")]
		public string First { get; set; }

		[XmlAttribute("КОСГУ")]
		public string Second { get; set; }

		[XmlAttribute("_x10")]
		public double X10 { get; set; }

		[XmlAttribute("_x11")]
		public double X11 { get; set; }

		[XmlAttribute("_x12")]
		public double X12 { get; set; }

		[XmlAttribute("_x13")]
		public double X13 { get; set; }

		[XmlAttribute("_x14")]
		public double X14 { get; set; }

		[XmlAttribute("_x2")]
		public double X2 { get; set; }

		[XmlAttribute("_x3")]
		public double X3 { get; set; }

		[XmlAttribute("_x4")]
		public double X4 { get; set; }

		[XmlAttribute("_x5")]
		public double X5 { get; set; }

		[XmlAttribute("_x6")]
		public double X6 { get; set; }

		[XmlAttribute("_x7")]
		public double X7 { get; set; }

		[XmlAttribute("_x8")]
		public double X8 { get; set; }

		[XmlAttribute("_x9")]
		public double X9 { get; set; }

		#endregion

	}

}