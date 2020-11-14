using System;
using System.Linq;
using System.Text;

using DbContex;

using NUnit.Framework;

using Parsers;

using Convert = ConvectorDbContex.Convert;

namespace UnitTest
{

	[TestFixture]
	public class UnitTestConvert
	{
		public UnitTestConvert() => Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

		[Test]
		public void TestConvert()
		{
			Convert.ParserTxtToDbContext(CoreParser.CreateInstance().ParseTxt(UnitTestParserTxt.Path));
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