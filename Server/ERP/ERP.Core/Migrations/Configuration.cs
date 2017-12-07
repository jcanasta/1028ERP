namespace ERP.Core.Migrations
{
    using ERP.Core.DAL.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ERP.Core.DAL.ERPDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ERP.Core.DAL.ERPDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Customers.AddOrUpdate(x => x.Name, new Customer { Name = "QM Builders", Address = "Dumanjug, Cebu", ContactPerson = "Allan Quirante", ContactNo = "123123123" });

            context.Employees.AddOrUpdate(x => x.FirstName, new Employee { FirstName = "Chuckie", LastName = "Macasero", Position = "Dev Team Leader" });

            context.Products.AddOrUpdate(x => x.Name,
                new Product() { Name = "CEMEX", Description = "CEMEX APO Masonry Cement", UnitPrice = 150 },
                new Product() { Name = "Valspar 82020", Description = "Valspar 82020 Gray Solid Color Concrete Sealer 1 Gallon", UnitPrice = 450 },
                new Product() { Name = "Rizal Cement", Description = "Rizal Portland Super Type 1P cement", UnitPrice = 145 },
                new Product() { Name = "Island Cement", Description = "Island Portland Type 1 Cement", UnitPrice = 140 },
                new Product() { Name = "Palitada King", Description = "Palitada King Masonry Cement", UnitPrice = 130 }
            );

            context.Users.AddOrUpdate(x => x.Username,
                new User { Username = "admin", Password = "admin123", MasterDataID = "1", Type = User.UserType.Employee },
                new User { Username = "qm", Password = "qm", MasterDataID = "1", Type = User.UserType.Customer }
            );
        }
    }
}
