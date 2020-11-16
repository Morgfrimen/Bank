using DbContex.Models;

using Microsoft.EntityFrameworkCore;

namespace DbContex
{

	public sealed class DbContextApp : DbContext
	{

		#region Constructors

		static DbContextApp() => GetDbContextApp = new DbContextApp();

		//Не использовать в повседневной жизни - нужен только для миграции
		public DbContextApp() => Database.EnsureCreated();

		#endregion

		#region Properties

		public static DbContextApp GetDbContextApp { get; }
		public DbSet<TableFirst> TableFirsts { get; set; }

		#endregion

		#region Methods

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql
			(Config.Config.Config.Con.Connection);

		#endregion

	}

}