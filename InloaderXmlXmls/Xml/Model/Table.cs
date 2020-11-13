using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace InloaderXmlXmls.Xml.Model
{
	[Serializable]
	public class Table
	{
		[XmlAttribute(nameof(Code))]
		public string Code { get; set; }

		[XmlElement(IsNullable = true)]
		public Data[] Data { get; set; }
	}

}