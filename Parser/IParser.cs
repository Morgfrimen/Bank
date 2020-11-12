using Parsers.ParserTXT.Models;

namespace Parsers
{

	public interface IParser
	{

		#region Methods

		OneRowTxt[] GetValueInTxtFile();

		OneRowTxt[] GetValueInTxtFileAsync();

		#endregion

	}

}