using System.Collections.Generic;

using DbContex.Models;

namespace InloaderXmlXmls
{

	public interface ILoader
	{

		#region Methods

		public void LoadFile();
		public void LoadFile(IList<TableFirst> tableFirsts);

		#endregion

	}

}