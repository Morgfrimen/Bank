using Bank.Models;

namespace Parsers
{

	public interface IParser
	{
		OneRowTxt[] GetValue();
	}

}