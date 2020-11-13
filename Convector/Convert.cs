using System;

using DbContex;
using DbContex.Models;

using Parsers;
using Parsers.ParserTXT.Models;

namespace Convector
{

	public static class Convert
	{

		#region Methods

		public static async void ParserTxtToDbContext(IParser parser)
		{
			DbContextApp app = DbContextApp.GetDbContextApp;
			OneRowTxt[] modelsParser = parser.GetValueInTxtFile();
			TableFirst[] tableFirsts = new TableFirst[modelsParser.Length];

			for (int index = 0; index < tableFirsts.Length; index++)
				tableFirsts[index] = new TableFirst
				{
					A1 = modelsParser[index].XA1,
					B1 = modelsParser[index].XB1,
					V1 = modelsParser[index].XV1,
					G1 = modelsParser[index].XG1,
					X2 = modelsParser[index].X2,
					X3 = modelsParser[index].X3,
					X4 = modelsParser[index].X4,
					X5 = modelsParser[index].X5,
					X6 = modelsParser[index].X6,
					X7 = modelsParser[index].X7,
					X8 = modelsParser[index].X8,
					X9 = modelsParser[index].X9,
					X10 = modelsParser[index].X10,
					X11 = modelsParser[index].X11,
					X12 = modelsParser[index].X12,
					X13 = modelsParser[index].X13,
					X14 = modelsParser[index].X14
				};
			app.TableFirsts.AddRange(tableFirsts);

			try
			{
				await app.SaveChangesAsync();
			}
			catch (Exception exception)
			{
				Logger.Logger.Error(exception, nameof(Convert), nameof(ParserTxtToDbContext));
				app.SaveChanges();
			}
		}

		#endregion

	}

}