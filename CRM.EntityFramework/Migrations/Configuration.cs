namespace CRM.EntityFramework.Migrations
{
    using Domain.Entities;
    using System;    
    using System.Data.Entity.Migrations;    

    internal sealed class Configuration : DbMigrationsConfiguration<CRM.EntityFramework.DataContext>
    {
        public Configuration()
        {
            //AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(CRM.EntityFramework.DataContext context)
        {           
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
