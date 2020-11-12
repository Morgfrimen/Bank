using System;
using System.Linq;

using DbContex;
using DbContex.Models;

using NUnit.Framework;

namespace UnitTest
{
	[TestFixture]
	public sealed class UnitTest_DbContex
	{
		[Test]
		public void TestDbContex()
		{
			using (DbContextApp db = new DbContextApp())
			{
				TableFirst tableFirst1 = new TableFirst(){A1 = 6000};
				TableFirst tableFirst2 = new TableFirst(){A1 = 99999};

				db.TableFirsts.AddRange(tableFirst1,tableFirst2);
				db.SaveChanges();

				var table = db.TableFirsts.ToList();
				table.ForEach(item=>Console.WriteLine(item.A1+Environment.NewLine));

				db.TableFirsts.RemoveRange(db.TableFirsts.Select(item=>item).ToArray());
				db.SaveChanges();

				if(!db.TableFirsts.Any())
					Console.WriteLine("База пуста");
			}
		}
	}

}