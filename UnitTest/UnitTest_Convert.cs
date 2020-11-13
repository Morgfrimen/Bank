using System;
using System.Linq;
using System.Text;

using NUnit.Framework;

using Parsers;

namespace UnitTest
{

	[TestFixture]
	public class UnitTest_Convert
	{
		public UnitTest_Convert()
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
		}

		[Test]
		public void TestConvert()
		{
			Convector.Convert.ParserTxtToDbContext(Core.CreateInstance().ParseTxt(UnitTest_ParserTxt.Path));
			DbContex.DbContextApp.GetDbContextApp.TableFirsts.ToList().ForEach(
				item =>
				{
					Console.WriteLine(item.A1);
				});
			Assert.AreEqual(DbContex.DbContextApp.GetDbContextApp.TableFirsts.Count(),161);

			DbContex.DbContextApp.GetDbContextApp.TableFirsts.RemoveRange(DbContex.DbContextApp.GetDbContextApp.TableFirsts);
			DbContex.DbContextApp.GetDbContextApp.SaveChanges();
		}
	}

}