using System;
using System.Xml.Serialization;

namespace InloaderXmlXmls.Xml.Model
{
	[Serializable]
	public class Report
	{
		[XmlAttribute(nameof(Code))]
		public string Code { get; set; }

		[XmlAttribute(nameof(AlbumCode))]
		public string AlbumCode { get; set; }

		public FormVariant FormVariant { get; set; }
	}

}