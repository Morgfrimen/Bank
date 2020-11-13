using InloaderXmlXmls.Xml;

namespace InloaderXmlXmls
{

	public sealed class CoreLoader
	{

		#region Static Fields and Constants

		private static CoreLoader _coreLoader;

		#endregion

		#region Methods

		public static CoreLoader CreateInstance()
		{
			_coreLoader ??= new CoreLoader();

			return _coreLoader;
		}

		#endregion

		public ILoader GetLoader(string path)
		{
			return new LoaderXml(path);
		}

	}

}