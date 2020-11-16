using System;
using System.Collections.Generic;
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

		private string _path;
		private string _filter = "Excel файл (*.xlsx)|*.xlsx|XML файл(*.xml)|*.xml";

		#endregion

		#region Constructors

		public InLoaderViewModels(IList<TableFirst> itemFirsts) => ItemFirsts = itemFirsts;

		#endregion

		#region Properties

		public ICommand LoadXlsxCommand { get; } = new RelayCommand
		(
			param =>
			{
				InLoaderViewModels vm = param as InLoaderViewModels;
				try
				{
					if (vm.ItemFirsts is null)
						throw new NullReferenceException("vm.ItemFirsts");

					ILoader loader = CoreLoader.CreateInstance().GetLoader(vm.Path, TypeLoader.Xlsx);
					loader.LoadFile(vm.ItemFirsts);
				}
				catch (Exception exception)
				{
					Logger.Logger.Error(exception, nameof(RelayCommand), nameof(LoadXlsxCommand));
				}
			}
		);

		public ICommand OpenFileDialogCommand { get; }= new RelayCommand(
			param =>
			{
				var vm = (param as InLoaderViewModels);
				if(vm is null)
					throw new NullReferenceException("ViewModels не найдена!");
				OpenFileDialog dialog = new OpenFileDialog();
				dialog.Filter = vm._filter;
				bool? result = dialog.ShowDialog();

				// ReSharper disable once PossibleInvalidOperationException
				if (result.Value)
				{
					vm.Path = dialog.FileName;

					return;
				}
			});

		public ICommand LoadXmlCommand { get; } = new RelayCommand
		(
			param =>
			{
				InLoaderViewModels vm = param as InLoaderViewModels;
				try
				{
					if (vm.ItemFirsts is null)
						throw new NullReferenceException("vm.ItemFirsts");

					ILoader loader = CoreLoader.CreateInstance().GetLoader(vm.Path, TypeLoader.Xml);
					loader.LoadFile(vm.ItemFirsts);
				}
				catch (Exception exception)
				{
					Logger.Logger.Error(exception, nameof(RelayCommand), nameof(LoadXmlCommand));
				}
			}
		);

		public IList<TableFirst> ItemFirsts { get; }

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