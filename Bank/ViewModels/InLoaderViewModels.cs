using System;
using System.Collections.Generic;
using System.Windows.Input;

using Bank.Command;

using DbContex.Models;

using InloaderXmlXmls;

namespace Bank.ViewModels
{

	//TODO: Path
	public sealed class InLoaderViewModels : BaseViewModels
	{

		#region Fields

		private string _path;

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