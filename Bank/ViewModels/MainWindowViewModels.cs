using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

using Bank.Command;

using DbContex;
using DbContex.Models;

using Microsoft.Win32;

using Parsers;

using Convert = ConvectorDbContex.Convert;

namespace Bank.ViewModels
{

	public sealed class MainWindowViewModels : BaseViewModels
	{

		#region Fields

		private bool _error;

		private double _heightMessageError;

		private IList<TableFirst> _itemSource;

		private bool _noClick = true;

		private double _opacityMainWindow;

		private string _path;

		private bool _showPopupInLoadButton = true;

		#endregion

		#region Events

		private event Action ErrorEvent;
		private event Action<bool> Pause;

		#endregion

		#region Constructors

		public MainWindowViewModels()
		{
			this.ErrorEvent += () =>
			{
				Task.Run
				(
					() =>
					{
						Error = !Error;
						Thread.Sleep(new TimeSpan(0, 0, 5));
						Error = !Error;
					}
				);
			};
			this.Pause += async res =>
			{
				await Task.Run
				(
					() =>
					{
						switch (res)
						{
							case true:
								while (true)
								{
									if (OpacityMainWindow >= 0.5 && OpacityMainWindow <= 0.9)
										OpacityMainWindow += 0.1;
									else
										OpacityMainWindow = 0.5;
									Thread.Sleep(new TimeSpan(0, 0, 0, 0, 500));
								}

							case false:
								OpacityMainWindow = 1.0;

								return;
						}
					}
				);
			};
		}

		#endregion

		#region Properties

		public ICommand ClearDbContext { get; } = new RelayCommand
		(
			param =>
			{
				(param as MainWindowViewModels).NoClick = false;

				try
				{
					Task task = Task.Run
					(
						() =>
						{
							(param as MainWindowViewModels).Pause.Invoke(true);
							DbContextApp.GetDbContextApp.TableFirsts.RemoveRange(DbContextApp.GetDbContextApp.TableFirsts);
							(param as MainWindowViewModels).ItemSource = null;
							(param as MainWindowViewModels).Pause.Invoke(false);
							Task<int> task = DbContextApp.GetDbContextApp.SaveChangesAsync();

							if (task.Exception != null)
							{
								Logger.Logger.Error(task.Exception, nameof(RelayCommand), nameof(LoadDataTxtFile));
								(param as MainWindowViewModels).ErrorEvent?.Invoke();

								throw new Exception($"Ошибка в потоке:{task.Exception.Message}");
							}
						}
					);

					if (task.Exception != null)
					{
						Logger.Logger.Error(task.Exception, nameof(RelayCommand), nameof(LoadDataTxtFile));
						(param as MainWindowViewModels).ErrorEvent?.Invoke();

						throw new Exception($"Ошибка в потоке:{task.Exception.Message}");
					}
				}
				catch
				{
					(param as MainWindowViewModels).ErrorEvent?.Invoke();
				}

				(param as MainWindowViewModels).NoClick = true;
			}
		);

		public ICommand InLoadClickCommand { get; } = new RelayCommand
		(
			param =>
			{
				MainWindowViewModels mainViewModel = param as MainWindowViewModels;

				try
				{
					(Application.Current as App).Inload.Show();
					(Application.Current as App).Inload.Focus();
					(Application.Current as App).Inload.DataContext = new InLoaderViewModels(mainViewModel.ItemSource)
					{
						Path = $@"{Environment.CurrentDirectory}"
					};

				}
				catch (Exception e)
				{
					Logger.Logger.Error(e, nameof(RelayCommand), nameof(InLoadClickCommand));
				}
			}
		);

		public ICommand LoadDataTxtFile { get; } = new RelayCommand
		(
			param =>
			{
				MainWindowViewModels mainViewModels = param as MainWindowViewModels;
				mainViewModels.NoClick = false;

				try
				{
					Task task = Task.Run
					(
						() =>
						{
							try
							{
								mainViewModels.Pause.Invoke(true);
								Convert.ParserTxtToDbContext(CoreParser.CreateInstance().ParseTxt(mainViewModels.Path));
								mainViewModels.ItemSource = DbContextApp.GetDbContextApp.TableFirsts.ToList();
								mainViewModels.Pause.Invoke(false);
							}
							catch
							{
								mainViewModels.ErrorEvent?.Invoke();
							}
						}
					);
				}
				catch
				{
					mainViewModels.ErrorEvent?.Invoke();
				}

				mainViewModels.NoClick = true;
			},
			param => (param as MainWindowViewModels).NoClick
		);

		public ICommand LoadDbContex { get; } = new RelayCommand
		(
			param =>
			{
				MainWindowViewModels mainViewModels = param as MainWindowViewModels;
				mainViewModels.NoClick = false;

				try
				{
					Task task = Task.Run
					(
						() =>
						{
							mainViewModels.ItemSource = DbContextApp.GetDbContextApp.TableFirsts.ToList();
						}
					);
				}
				catch
				{
					mainViewModels.ErrorEvent?.Invoke();
				}

				mainViewModels.NoClick = true;
			},
			param => (param as MainWindowViewModels).NoClick
		);

		public ICommand OpenFileDialog { get; } = new RelayCommand
		(
			param =>
			{
				MainWindowViewModels path = param as MainWindowViewModels;
				OpenFileDialog dialog = new OpenFileDialog();
				dialog.Filter = "Текстовый файл (*.txt)|*.txt";
				bool? result = dialog.ShowDialog();

				// ReSharper disable once PossibleInvalidOperationException
				if (result.Value)
				{
					path.Path = dialog.FileName;

					return;
				}

				path.Path = string.Empty;
			}
		);

		public ICommand SaveDbContext { get; } = new RelayCommand
		(
			param =>
			{
				MainWindowViewModels mainViewModels = param as MainWindowViewModels;
				mainViewModels.NoClick = false;

				try
				{
					Task task = Task.Run
					(
						() =>
						{
							try
							{
								DbContextApp.GetDbContextApp.TableFirsts.RemoveRange(DbContextApp.GetDbContextApp.TableFirsts);
								DbContextApp.GetDbContextApp.TableFirsts.AddRange(mainViewModels.ItemSource);
								Task<int> task = DbContextApp.GetDbContextApp.SaveChangesAsync();
							}
							catch (Exception exception)
							{
								Logger.Logger.Error(exception, nameof(RelayCommand), nameof(LoadDataTxtFile));
								mainViewModels.ErrorEvent?.Invoke();
							}
						}
					);
				}
				catch
				{
					mainViewModels.ErrorEvent?.Invoke();
				}

				mainViewModels.NoClick = true;
			},
			param => (param as MainWindowViewModels).NoClick
		);

		public bool Error
		{
			get => _error;
			set
			{
				_error = value;
				OnPropertyChanged(nameof(Error));
				HeightMessageError = value ? 30 : 0;
			}
		}

		public double HeightMessageError
		{
			get => _heightMessageError;
			set
			{
				_heightMessageError = value;
				OnPropertyChanged(nameof(HeightMessageError));
			}
		}

		public IList<TableFirst> ItemSource
		{
			get => _itemSource;
			set
			{
				_itemSource = value;
				OnPropertyChanged(nameof(ItemSource));
			}
		}

		public bool NoClick
		{
			get => _noClick;
			set
			{
				_noClick = value;
				OnPropertyChanged(nameof(NoClick));
				LoadDataTxtFile.CanExecute(this);
				LoadDbContex.CanExecute(this);
				SaveDbContext.CanExecute(this);
				ClearDbContext.CanExecute(this);

			}
		}

		public double OpacityMainWindow
		{
			get => _opacityMainWindow;
			set
			{
				_opacityMainWindow = value;
				OnPropertyChanged(nameof(OpacityMainWindow));
			}
		}

		public string Path
		{
			get => _path;
			set
			{
				_path = value;
				OnPropertyChanged(nameof(Path));
			}
		}

		public bool ShowPopupInLoadButton
		{
			get => _showPopupInLoadButton;
			set
			{
				_showPopupInLoadButton = value;
				OnPropertyChanged(nameof(ShowPopupInLoadButton));
			}
		}

		#endregion

	}

}