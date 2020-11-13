using System.ComponentModel.DataAnnotations.Schema;

namespace DbContex.Models
{
	[Table("Table")]
	public sealed class TableFirst
	{
		public int Id { get; set; }

		[Column("1a")]
		public double A1 { get; set; }

		[Column("1б")]
		public double B1 { get; set; }

		[Column("1в")]
		public double V1 { get; set; }

		[Column("1г")]
		public double G1 { get; set; }

		public double X2 { get; set; }
		public double X3 { get; set; }
		public double X4 { get; set; }
		public double X5 { get; set; }
		public double X6 { get; set; }
		public double X7 { get; set; }
		public double X8 { get; set; }
		public double X9 { get; set; }
		public double X10 { get; set; }
		public double X11 { get; set; }
		public double X12 { get; set; }
		public double X13 { get; set; }
		public double X14 { get; set; }


	}

}