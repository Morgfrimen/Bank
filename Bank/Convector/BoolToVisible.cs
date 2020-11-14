using System;
using System.Globalization;
using System.Windows;

namespace Bank.Convector
{

	public class BoolToVisible : BaseConvector
	{

		#region Methods

		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
			(bool) value ? Visibility.Visible : Visibility.Collapsed;

		#endregion

	}

}