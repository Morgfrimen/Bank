using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;

using Bank.View;

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
			try
			{
				Window mainWindow = window ?? throw new ArgumentException(nameof(App));
				ShowWindow(mainWindow);
				var testConfig = Config.Config.Con;
			}
			catch (Exception ex)
			{
				Logger.Logger.Error(ex, nameof(App), "Constructor");
			}
			Logger.Logger.InformationSuccesMethod(nameof(App),"Constructor");

		}

		#endregion

		#region Method

		private void ShowWindow(params Window[] windows)
		{
			foreach (Window window in windows)
				window.Show();
		}

		#endregion

	}

}