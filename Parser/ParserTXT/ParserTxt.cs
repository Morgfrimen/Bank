using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using Parsers;
using Parsers.ParserTXT.Models;

namespace ParserTxt
{

	internal sealed class ParserTxt : IParser
	{

		#region Fields

		private readonly string _path;

		#endregion

		#region Constructors

		public ParserTxt(string path) => _path = path;

		#endregion

		#region Methods

		public OneRowTxt[] GetValueInTxtFile()
		{
			string contentTxtFile;

			using (StreamReader streamReader = new StreamReader(_path, Encoding.GetEncoding(1251)))
			{
				contentTxtFile = streamReader.ReadToEnd();
			}

			string patternReplace = string.Empty;

			foreach (string banStr in Config.Config.Config.Con.BanString)
				/*patternReplace += $@".*\{banStr}.*{Environment.NewLine}"*/
				if (banStr.Length > 1)
					patternReplace += $@".*{banStr}.*{Environment.NewLine}|";
				else
					patternReplace += $@".*\{banStr}.*{Environment.NewLine}|";

			contentTxtFile = Regex.Replace(contentTxtFile, patternReplace, string.Empty, RegexOptions.Compiled);
			string[] contentArray = contentTxtFile.Split(Environment.NewLine);
			string patternValue = string.Empty;

			for (int i = 0; i < typeof(OneRowTxt).GetProperties().Length; i++)
				patternValue += $@"(\d+|\d+,\d+)\{Config.Config.Config.Con.Separator}";
			OneRowTxt[] orOneRowTxts = new OneRowTxt[contentArray.Length];

			for (int index = 0; index < contentArray.Length; index++)
			{
				string s = contentArray[index];
				Match match = Regex.Match(s, patternValue);

				try
				{
					foreach (OneRowTxt orOneRowTxt in orOneRowTxts)
						orOneRowTxts[index] = new OneRowTxt
						{
							XA1 = match.Groups[1].Value,
							XB1 = match.Groups[2].Value,
							XV1 = match.Groups[3].Value,
							XG1 = match.Groups[4].Value,
							X2 = double.TryParse(match.Groups[5].Value, out double val5) ? val5 : default,
							X3 = double.TryParse(match.Groups[6].Value, out double val6) ? val6 : default,
							X4 = double.TryParse(match.Groups[7].Value, out double val7) ? val7 : default,
							X5 = double.TryParse(match.Groups[8].Value, out double val8) ? val8 : default,
							X6 = double.TryParse(match.Groups[9].Value, out double val9) ? val9 : default,
							X7 = double.TryParse(match.Groups[10].Value, out double val10) ? val10 : default,
							X8 = double.TryParse(match.Groups[11].Value, out double val11) ? val11 : default,
							X9 = double.TryParse(match.Groups[12].Value, out double val12) ? val12 : default,
							X10 = double.TryParse(match.Groups[13].Value, out double val13) ? val13 : default,
							X11 = double.TryParse(match.Groups[14].Value, out double val14) ? val14 : default,
							X12 = double.TryParse(match.Groups[15].Value, out double val15) ? val15 : default,
							X13 = double.TryParse(match.Groups[16].Value, out double val16) ? val16 : default,
							X14 = double.TryParse(match.Groups[17].Value, out double val17) ? val17 : default
						};
				}
				catch (Exception exception)
				{
					Logger.Logger.Error(exception, nameof(ParserTxt), "Цикл при присвоении значений из Regex");

					return null;
				}
			}

			return orOneRowTxts;
		}

		public OneRowTxt[] GetValueInTxtFileAsync() => throw new NotImplementedException();

		#endregion

	}

}