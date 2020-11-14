using System;

using InloaderXmlXmls.Xlsx;
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

		public ILoader GetLoader(string path, TypeLoader typeLoader)
		{
            try
            {
                switch (typeLoader)
                {
                    case TypeLoader.Xml:
                        return new LoaderXml(path);
                    case TypeLoader.Xlsx:
                        return new LoaderXlsx(path);
                    default:
                        throw new Exception("Ошибка с TypeLoader");
                }
            }
            catch (Exception exception)
            {
                Logger.Logger.Error(exception,nameof(CoreLoader),nameof(GetLoader));
                throw;
            }
		}

	}

}