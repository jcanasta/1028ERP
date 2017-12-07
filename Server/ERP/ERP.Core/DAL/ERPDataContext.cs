namespace ERP.Core.DAL
{
    using ERP.Core.DAL.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ERPDataContext : DbContext
    {
        // Your context has been configured to use a 'ERPDataContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ERP.Core.DAL.ERPDataContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ERPDataContext' 
        // connection string in the application configuration file.
        public ERPDataContext()
            : base("name=ERPDataContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<SalesOrder> SalesOrders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
    }
}