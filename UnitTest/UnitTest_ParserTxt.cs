using System.Text;

using NUnit.Framework;

using Parsers;
using Parsers.ParserTXT.Models;

namespace UnitTest
{

	[TestFixture]
	public class UnitTest_ParserTxt
	{
		public UnitTest_ParserTxt()
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			Core.CreateInstance();
		}

		internal static string Path { get; set; } = @"..\..\..\..\Задание\Пример загружаемого файла 1.txt";

		//так себе тест, он нужен был для дебага парсера
		[Test]
		[Order(0)]
		public void TestMethod_GetString()
		{
			IParser newStr = Core.CreateInstance().ParseTxt(Path);
			OneRowTxt[] result = newStr.GetValueInTxtFile();
			Assert.AreEqual(result.Length, 161);
		}
	}

}