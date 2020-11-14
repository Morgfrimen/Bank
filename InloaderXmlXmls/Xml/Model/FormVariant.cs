using System;
using System.Xml.Serialization;

namespace InloaderXmlXmls.Xml.Model
{

	[Serializable]
	public class FormVariant
	{

		#region Properties

		[XmlAttribute(nameof(NsiVariantCode))]
		public string NsiVariantCode { get; set; }

		[XmlAttribute(nameof(Number))]
		public uint Number { get; set; }

		public Table Table { get; set; }

		#endregion

	}

}