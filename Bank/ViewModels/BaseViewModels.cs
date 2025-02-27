﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

using Bank.Annotations;

namespace Bank.ViewModels
{

	public abstract class BaseViewModels : INotifyPropertyChanged
	{

		#region Events

		public event PropertyChangedEventHandler? PropertyChanged;

		#endregion

		#region Methods

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => this.PropertyChanged?.Invoke
			(this, new PropertyChangedEventArgs(propertyName));

		protected virtual void OnPropertyChangers(params string[] propertyName)
		{
			foreach (string s in propertyName)
				OnPropertyChanged(s);
		}

		#endregion

	}

}