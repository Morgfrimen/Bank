using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

			contentTxtFile = Regex.Replace(contentTxtFile, patternReplace, string.Empty);
			string[] contentArray = contentTxtFile.Split(Environment.NewLine);
			string patternValue = string.Empty;

			for (int i = 0; i < typeof(OneRowTxt).GetProperties().Length; i++)
				patternValue += $@"(\d+|\d+,\d+)\{Config.Config.Config.Con.Separator}";
			OneRowTxt[] orOneRowTxts = new OneRowTxt[contentArray.Length];

			for (int index = 0; index < contentArray.Length; index++)
			{
				string s = contentArray[index];
				Match match = Regex.Match(s, patternValue);

				foreach (OneRowTxt orOneRowTxt in orOneRowTxts)
				{
					List<PropertyInfo> one = new OneRowTxt().GetType()
						.GetProperties()
						.ToList();
					orOneRowTxts[index] = new OneRowTxt();
					int count = 0;
					one.ForEach
					(
						item =>
						{
							count++;
							if (double.TryParse(match.Groups[count].Value, out double value))
								item.SetValue(orOneRowTxts[index], value);
							else
								item.SetValue(orOneRowTxts[index], default(double));
						}
					);
				}
			}

			return orOneRowTxts; //TODO!
		}

		public OneRowTxt[] GetValueInTxtFileAsync() => throw new NotImplementedException();

		#endregion

	}

}