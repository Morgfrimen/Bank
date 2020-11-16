using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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

		public App() : this(new MainWindow()) { }

		private App([NotNull] Window window)
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

			try
			{
				Window mainWindow = window ?? throw new ArgumentException(nameof(App));
				ShowWindow(mainWindow);
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

	

		#endregion

		#region Methods

		private void ShowWindow(params Window[] windows)
		{
			foreach (Window window in windows)
				window.Show();

			windows.First().Closed += (sendex, e) =>
			{
				Process.GetCurrentProcess().Kill(); //Для коректного закрытия приложения после публикации
			};
		}

		#endregion

	}

}