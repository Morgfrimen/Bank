using System.ComponentModel.DataAnnotations.Schema;

namespace DbContex.Models
{

	[Table("Table")]
	public sealed class TableFirst
	{

		#region Properties

		[Column("1a")]
		public string A1 { get; set; } = "string.Empty";

		[Column("1б")]
		public string B1 { get; set; } = "string.Empty";

		[Column("1г")]
		public string G1 { get; set; } = "string.Empty";

		public int Id { get; set; }

		[Column("1в")]
		public string V1 { get; set; } = "string.Empty";

		public double X10 { get; set; }
		public double X11 { get; set; }
		public double X12 { get; set; }
		public double X13 { get; set; }
		public double X14 { get; set; }

		public double X2 { get; set; }
		public double X3 { get; set; }
		public double X4 { get; set; }
		public double X5 { get; set; }
		public double X6 { get; set; }
		public double X7 { get; set; }
		public double X8 { get; set; }
		public double X9 { get; set; }

		#endregion

	}

}