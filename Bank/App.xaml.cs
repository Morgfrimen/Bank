using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Windows;

using Bank.View;

using Parsers;

namespace Bank
{

	/// <summary>
	///     Interaction logic for App.xaml
	/// </summary>
	public sealed partial class App : Application
	{

		#region Constructors

		public App() : this(new MainWindow(), new InLoad()) { }

		private App([NotNull] Window window, [NotNull] Window inload)
		{
			Inload = inload;
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

			try
			{
				Window mainWindow = window ?? throw new ArgumentException(nameof(App));
				ShowWindow(mainWindow);
				inload = new InLoad();
			}
			catch (Exception ex)
			{
				Logger.Logger.Error(ex, nameof(App), "Constructor");
			}

			//Создание ядра для парсера
			CoreParser.CreateInstance();

			//Создание конфига
			_ = Config.Config.Config.Con;
		}

		#endregion

		#region Properties

		public Window Inload { get; }

		#endregion

		#region Methods

		private void ShowWindow(params Window[] windows)
		{
			foreach (Window window in windows)
				window.Show();
		}

		#endregion

	}

}