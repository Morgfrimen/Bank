using System;
using System.Xml.Serialization;

namespace InloaderXmlXmls.Xml.Model
{

	[Serializable]
	public class Table
	{

		#region Properties

		[XmlAttribute(nameof(Code))]
		public string Code { get; set; }

		[XmlElement(IsNullable = true)]
		public Data[] Data { get; set; }

		#endregion

	}

}