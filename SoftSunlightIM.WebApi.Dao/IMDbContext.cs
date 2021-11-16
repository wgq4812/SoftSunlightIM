using Microsoft.EntityFrameworkCore;
using SoftSunlightIM.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftSunlightIM.WebApi.Dao
{
    public class IMDbContext : DbContext
    {
        public DbSet<User> UserDbSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
        }

    }
}
