using System;

using DbContex.Models;

using Microsoft.EntityFrameworkCore;

namespace DbContex
{
    public sealed class DbContextApp : DbContext
    {
		public static DbContextApp GetDbContextApp { get; }

		static DbContextApp()
		{
			GetDbContextApp = new DbContextApp();
		}


	    private DbContextApp()
	    {
		    Database.EnsureCreated();
	    }

	    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	    {
		    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=123123");
	    }
        public DbSet<TableFirst> TableFirsts { get; set; }
    }
}
