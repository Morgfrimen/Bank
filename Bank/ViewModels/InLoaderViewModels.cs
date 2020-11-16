using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

using Bank.Command;

using DbContex.Models;

using InloaderXmlXmls;

using Microsoft.Win32;

namespace Bank.ViewModels
{

	//TODO: Path
	public sealed class InLoaderViewModels : BaseViewModels
	{

		#region Fields

		private readonly string _filter = "Excel файл (*.xlsx)|*.xlsx|XML файл(*.xml)|*.xml";

		private string _path;

		#endregion

		#region Constructors

		public InLoaderViewModels(IList<TableFirst> itemFirsts) => ItemFirsts = itemFirsts;

		#endregion

		#region Properties

		public IList<TableFirst> ItemFirsts { get; }

		private string _message;

		public string Message
		{
			get => _message;
			set { _message = value; OnPropertyChanged(nameof(Message)); }
		}

		public ICommand LoadXlsxCommand { get; } = new RelayCommand
		(
			param =>
			{
				
				InLoaderViewModels vm = param as InLoaderViewModels;

				vm.Message = "Выгрузка началась";

				Match math = Regex.Match(vm.Path, @"\\.*\.xlsx");
				if (!math.Success)
					vm.Path += @"\InLoadXlsx.xlsx";

				try
				{
					Task.Run
					(
						() =>
						{
							if (vm.ItemFirsts is null)
								throw new NullReferenceException("vm.ItemFirsts");

							ILoader loader = CoreLoader.CreateInstance().GetLoader(vm.Path, TypeLoader.Xlsx);
							loader.LoadFile(vm.ItemFirsts);
							vm.Message = "Выгрузка закончилась";
							vm.MessageEmpty();
							vm.Path = vm.Path.Replace(@"\InLoadXlsx.xlsx",string.Empty);
						}
					);
				}
				catch (Exception exception)
				{
					Logger.Logger.Error(exception, nameof(RelayCommand), nameof(LoadXlsxCommand));
				}
			}
		);


		private void MessageEmpty()
		{
			Task.Run
			(
				() =>
				{
					Thread.Sleep(new TimeSpan(0,0,2));
					Message = string.Empty;
				}
			);
		}


		public ICommand LoadXmlCommand { get; } = new RelayCommand
		(
			param =>
			{
				InLoaderViewModels vm = param as InLoaderViewModels;
				vm.Message = "Выгрузка началась";
				Match math = Regex.Match(vm.Path, @"\\.*\.xml");
				if (!math.Success)
					vm.Path += @"\InLoadXml.xml";

				try
				{
					Task.Run
					(
						() =>
						{
							if (vm.ItemFirsts is null)
								throw new NullReferenceException("vm.ItemFirsts");

							ILoader loader = CoreLoader.CreateInstance().GetLoader(vm.Path, TypeLoader.Xml);
							loader.LoadFile(vm.ItemFirsts);
							vm.Message = "Выгрузка закончилась";
							vm.MessageEmpty();
							vm.Path = vm.Path.Replace(@"\InLoadXml.xml", string.Empty);
						}
					);
				}
				catch (Exception exception)
				{
					Logger.Logger.Error(exception, nameof(RelayCommand), nameof(LoadXmlCommand));
				}
			}
		);

		public ICommand OpenFileDialogCommand { get; } = new RelayCommand
		(
			param =>
			{
				InLoaderViewModels vm = param as InLoaderViewModels;

				if (vm is null)
					throw new NullReferenceException("ViewModels не найдена!");

				OpenFileDialog dialog = new OpenFileDialog();
				dialog.Filter = vm._filter;
				bool? result = dialog.ShowDialog();

				// ReSharper disable once PossibleInvalidOperationException
				if (result.Value)
					vm.Path = dialog.FileName;
			}
		);

		public string Path
		{
			get => _path;
			set
			{
				_path = value;
				OnPropertyChanged(nameof(Path));
			}
		}

		#endregion

	}

}