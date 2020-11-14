using System;
using System.Globalization;
using System.Windows.Data;

namespace Bank.Convector
{

	public abstract class BaseConvector : IValueConverter
	{

		#region Methods

		public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

		public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

		#endregion

	}

}