namespace CRM.EntityFramework.Migrations
{
    using Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CRM.EntityFramework.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CRM.EntityFramework.DataContext context)
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
            context.QuestionTypes.AddOrUpdate(
              p => p.Name,
              new QuestionType { Name = "Short Text",AddedDate = DateTime.Today,IsDeleted = false },
              new QuestionType { Name = "Long Text", AddedDate = DateTime.Today, IsDeleted = false },
              new QuestionType { Name = "Numeric", AddedDate = DateTime.Today, IsDeleted = false },
              new QuestionType { Name = "Yes/No", AddedDate = DateTime.Today, IsDeleted = false },
              new QuestionType { Name = "Selection", AddedDate = DateTime.Today, IsDeleted = false },
              new QuestionType { Name = "Photo", AddedDate = DateTime.Today, IsDeleted = false },
              new QuestionType { Name = "Date", AddedDate = DateTime.Today, IsDeleted = false },
              new QuestionType { Name = "Section Header", AddedDate = DateTime.Today, IsDeleted = false },
              new QuestionType { Name = "Bar Code", AddedDate = DateTime.Today, IsDeleted = false },
              new QuestionType { Name = "Product", AddedDate = DateTime.Today, IsDeleted = false }
            );

            context.Tenants.AddOrUpdate(
              p => p.Name,
              new Tenant { Name = "SA FMCG", Address="No 20 Hobart Road, Bryanston", AddedDate = DateTime.Today, IsDeleted = false },
              new Tenant { Name = "Ascendis Health", Address = "No 20 William Nicol Road, Bryanston", AddedDate = DateTime.Today, IsDeleted = false }
           );

        }
    }
}
