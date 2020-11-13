namespace Parsers.ParserTXT.Models
{

	public sealed class OneRowTxt
	{

		#region Constructors

		public OneRowTxt(double xa1, double xb1, double xv1, double xg1, double x2, double x3,
			double x4, double x5, double x6, double x7, double x8, double x9,
			double x10, double x11, double x12, double x13, double x14)
		{
			XA1 = xa1;
			XB1 = xb1;
			XV1 = xv1;
			XG1 = xg1;
			X2 = x2;
			X3 = x3;
			X4 = x4;
			X5 = x5;
			X6 = x6;
			X7 = x7;
			X8 = x8;
			X9 = x9;
			X10 = x10;
			X11 = x11;
			X12 = x12;
			X13 = x13;
			X14 = x14;
		}

		internal OneRowTxt() { }

		#endregion

		#region Properties

		public double X10 { get; internal set; }
		public double X11 { get; internal set; }
		public double X12 { get; internal set; }
		public double X13 { get; internal set; }
		public double X14 { get; internal set; }

		public double X2 { get; internal set; }
		public double X3 { get; internal set; }
		public double X4 { get; internal set; }
		public double X5 { get; internal set; }
		public double X6 { get; internal set; }
		public double X7 { get; internal set; }
		public double X8 { get; internal set; }
		public double X9 { get; internal set; }

		/// <summary>
		///     1a
		/// </summary>
		public double XA1 { get; internal set; }

		/// <summary>
		///     1б
		/// </summary>
		public double XB1 { get; internal set; }

		/// <summary>
		///     1г
		/// </summary>
		public double XG1 { get; internal set; }

		/// <summary>
		///     1в
		/// </summary>
		public double XV1 { get; internal set; }

		#endregion

		//Порядок должен быть строгим, так как в паресе используется рефлексия
	}

}