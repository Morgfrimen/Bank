namespace Parsers
{

	public sealed  class Core
	{
		private static Core _core;
		public static Core CreateInstance()
		{
			_core ??= new Core();
			return _core;
		}


		public IParser ParseTxt(string path)
		{
			return new ParserTxt.ParserTxt(path);
		}

	}

}