using System;

using Bank.Models;

using Parsers;

namespace ParserTxt
{

	internal sealed class ParserTxt : IParser
	{
		private readonly string _path;
		private readonly string pattern = $"";
		public ParserTxt(string path)
		{
			_path = path;
		}

		#region Implementation of IParser

		public OneRowTxt[] GetValue()
		{
			throw new NotImplementedException();
		}

		#endregion

	}
}
