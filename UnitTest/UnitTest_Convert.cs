using System;
using System.Linq;
using System.Text;

using DbContex;

using NUnit.Framework;

using Parsers;

using Convert = Convector.Convert;

namespace UnitTest
{

	[TestFixture]
	public class UnitTest_Convert
	{
		public UnitTest_Convert() => Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

		[Test]
		public void TestConvert()
		{
			Convert.ParserTxtToDbContext(Core.CreateInstance().ParseTxt(UnitTest_ParserTxt.Path));
			DbContextApp.GetDbContextApp.TableFirsts.ToList()
				.ForEach
				(
					item =>
					{
						Console.WriteLine(item.A1);
					}
				);
			Assert.AreEqual(DbContextApp.GetDbContextApp.TableFirsts.Count(), 161);

			DbContextApp.GetDbContextApp.TableFirsts.RemoveRange(DbContextApp.GetDbContextApp.TableFirsts);
			DbContextApp.GetDbContextApp.SaveChanges();
		}
	}

}