namespace Parsers
{

	public sealed class Core
	{

		#region Static Fields and Constants

		private static Core _core;

		#endregion

		#region Methods

		public static Core CreateInstance()
		{
			_core ??= new Core();

			return _core;
		}

		public IParser ParseTxt(string path) => new ParserTxt.ParserTxt(path);

		#endregion

	}

}