namespace Parsers
{

	public sealed class CoreParser
	{

		#region Static Fields and Constants

		private static CoreParser _coreParser;

		#endregion

		#region Methods

		public static CoreParser CreateInstance()
		{
			_coreParser ??= new CoreParser();

			return _coreParser;
		}

		public IParser ParseTxt(string path) => new ParserTxt.ParserTxt(path);

		#endregion

	}

}