using System.Text;

using NUnit.Framework;

using Parsers;
using Parsers.ParserTXT.Models;

namespace UnitTest
{

	[TestFixture]
	public class UnitTestParserTxt
	{
		public UnitTestParserTxt()
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			CoreParser.CreateInstance();
		}

		internal static string Path { get; set; } = @"..\..\..\..\Задание\Пример загружаемого файла 1.txt";

		//так себе тест, он нужен был для дебага парсера
		[Test]
		[Order(0)]
		public void TestMethod_GetString()
		{
			IParser newStr = CoreParser.CreateInstance().ParseTxt(Path);
			OneRowTxt[] result = newStr.GetValueInTxtFile();
			Assert.AreEqual(result.Length, 161);
		}
	}

}