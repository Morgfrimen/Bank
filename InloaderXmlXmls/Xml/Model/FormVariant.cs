using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace InloaderXmlXmls.Xml.Model
{
    [Serializable]
	public class FormVariant
	{
		[XmlAttribute(nameof(Number))]
		public uint Number { get; set; }

		[XmlAttribute(nameof(NsiVariantCode))]
		public string NsiVariantCode { get; set; }

		public Table Table { get; set; }
	}

}