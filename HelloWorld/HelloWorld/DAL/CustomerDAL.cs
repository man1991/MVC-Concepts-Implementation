using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HelloWorld.Models;

namespace HelloWorld.DAL
{
    /// <summary>
    /// DbSet class is generic class which belongs to CustomerDAL and it's specific to entity framework
    /// Whenever entity framework wants to return customer object, supplier object or table records it's type of DbSet
    /// Name of connection string in Web.config should be same as name of Data access layer class e.g. CustomerDAL
    /// </summary>
    public class CustomerDAL : DbContext
    {
        //to help class appropiately match table into database
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().ToTable("tblCustomer");
        }
        public DbSet<Customer> Customers { get; set; }
    }
}