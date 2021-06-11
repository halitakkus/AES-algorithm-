using Application.Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Core.Configuration.Context;

namespace Application.DataAccess.Concrete.EntityFramework.Context
{
    /// <summary>
    /// AsminDbContext contains database entities.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString;

        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<User> Users { get; set; }
     
  

        /// <summary>
        ///  provides normally MySQL.
        /// </summary>
        /// <param name="optionsBuilder">DbContextOptionsBuilder instance.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_connectionString);
        }
    }
}
