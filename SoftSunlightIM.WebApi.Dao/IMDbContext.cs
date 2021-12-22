using Microsoft.EntityFrameworkCore;
using SoftSunlightIM.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftSunlightIM.WebApi.Dao
{
    public class IMDbContext : DbContext
    {
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(@"Server=localhost;port=3306;database=softsunlightim;uid=root;pwd=123456;charset=utf8");
        }

    }
}
