using Kerialis.Datas.DbSeeds;
using Kerialis.Datas.Entities.Configurations;
using Kerialis.Datas.Entities.V1;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kerialis.Datas.DbContexts
{
    public class KerialisContext :DbContext
    {

        public KerialisContext(DbContextOptions<KerialisContext> options) : base(options)
        {}

        public DbSet<User> User { get; set; }
        public DbSet<Expense> Expense { get; set; }
        public DbSet<Expense> Currency { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
            modelBuilder.ApplyConfiguration(new CurrencyDbSeed());
            modelBuilder.ApplyConfiguration(new UserDbSeed());

            base.OnModelCreating(modelBuilder);
        }
    }
}
