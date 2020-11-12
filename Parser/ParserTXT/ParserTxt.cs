using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using Bank.Models;

using Parsers;

namespace ParserTxt
{

	internal sealed class ParserTxt : IParser
	{
		private readonly string _path;
		
		public ParserTxt(string path)
		{
			_path = path;
		}

		#region Implementation of IParser

		public OneRowTxt[] GetValueInTxtFile()
		{
			string contentTxtFile;
			using (StreamReader streamReader = new StreamReader(_path,Encoding.Unicode))
			{
				contentTxtFile = streamReader.ReadToEnd();
			}

			string creatingPatternReplase = string.Empty;

			foreach (string banStr in Config.Config.Config.Con.BanString)
			{
				creatingPatternReplase += $".*{banStr}.*";
			}

            contentTxtFile = Regex.Replace(contentTxtFile, creatingPatternReplase, string.Empty);

            return null; //TODO!
		}

		public OneRowTxt[] GetValueInTxtFileAsync() => throw new NotImplementedException();

		#endregion

	}
}
