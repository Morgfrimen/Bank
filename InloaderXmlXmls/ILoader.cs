using System.Collections.Generic;

using DbContex.Models;

namespace InloaderXmlXmls
{

	public interface ILoader
	{
		public void LoadXmlFile();
		public void LoadXmlFile(IList<TableFirst> tableFirsts);
	}

}