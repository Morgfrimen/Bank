using System;
using System.Text;

using InloaderXmlXmls;

using NUnit.Framework;

using Parsers;

namespace UnitTest
{

	[TestFixture]
	public class UnitTestLoader
	{
		public UnitTestLoader() => Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

		[Test]
		public void LoadXml()
		{
			var parsetTxt = CoreParser.CreateInstance().ParseTxt(UnitTestParserTxt.Path);
			Convector.Convert.ParserTxtToDbContext(parsetTxt);
			string path = $@"{Environment.CurrentDirectory}\{nameof(LoadXml)}.xml";
			ILoader loader = CoreLoader.CreateInstance().GetLoader(path);
			loader.LoadXmlFile();
			DbContex.DbContextApp.GetDbContextApp.TableFirsts.RemoveRange(DbContex.DbContextApp.GetDbContextApp.TableFirsts);
			DbContex.DbContextApp.GetDbContextApp.SaveChanges();
		}
	}

}