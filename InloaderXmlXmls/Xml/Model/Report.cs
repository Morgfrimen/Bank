using System;
using System.Xml.Serialization;

namespace InloaderXmlXmls.Xml.Model
{

	[Serializable]
	public class Report
	{

		#region Properties

		[XmlAttribute(nameof(AlbumCode))]
		public string AlbumCode { get; set; }

		[XmlAttribute(nameof(Code))]
		public string Code { get; set; }

		public FormVariant FormVariant { get; set; }

		#endregion

	}

}