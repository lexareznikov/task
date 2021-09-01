
using Domain.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;

namespace Domain
{
    public class EFDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseNpgsql(@"Server=localhost;Port=5432;Database=task;User Id=postgres;Password=sys123;");
        }
        public virtual DbSet<ObjectClass> ObjectClasses { get; set; }
        public virtual DbSet<RefType> RefTypes { get; set; }
        public virtual DbSet<AreaChanging> AreaChangings{ get; set; }
       

    }
}
