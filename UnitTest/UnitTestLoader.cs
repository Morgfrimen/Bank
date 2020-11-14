using System;
using System.Text;

using DbContex;

using InloaderXmlXmls;

using NUnit.Framework;

using Parsers;

using Convert = ConvectorDbContex.Convert;

namespace UnitTest
{

	[TestFixture]
	public class UnitTestLoader
	{
		public UnitTestLoader() => Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

		[Test]
		public void LoadXml()
		{
			IParser parsetTxt = CoreParser.CreateInstance().ParseTxt(UnitTestParserTxt.Path);
			Convert.ParserTxtToDbContext(parsetTxt);
			string path = $@"{Environment.CurrentDirectory}\{nameof(LoadXml)}.xml";
			ILoader loader = CoreLoader.CreateInstance().GetLoader(path, TypeLoader.Xml);
			loader.LoadFile();
			DbContextApp.GetDbContextApp.TableFirsts.RemoveRange(DbContextApp.GetDbContextApp.TableFirsts);
			DbContextApp.GetDbContextApp.SaveChanges();
		}

		[Test]
		public void LoadXlsx()
		{
			DbContextApp.GetDbContextApp.TableFirsts.RemoveRange(DbContextApp.GetDbContextApp.TableFirsts);
			DbContextApp.GetDbContextApp.SaveChanges();

			IParser parsetTxt = CoreParser.CreateInstance().ParseTxt(UnitTestParserTxt.Path);
			Convert.ParserTxtToDbContext(parsetTxt);
			string path = $@"{Environment.CurrentDirectory}\{nameof(LoadXlsx)}.Xlsx";
			ILoader loader = CoreLoader.CreateInstance().GetLoader(path, TypeLoader.Xlsx);
			loader.LoadFile();
			DbContextApp.GetDbContextApp.TableFirsts.RemoveRange(DbContextApp.GetDbContextApp.TableFirsts);
			DbContextApp.GetDbContextApp.SaveChanges();
		}
	}

}