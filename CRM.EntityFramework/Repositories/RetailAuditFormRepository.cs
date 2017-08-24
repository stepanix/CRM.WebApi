using CRM.Domain.Entities;
using CRM.Domain.Repositories;
using CRM.EntityFramework.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.EntityFramework.Repositories
{
    public class RetailAuditFormRepository : ORMBaseRepository<RetailAuditForm, int>, IRetailAuditFormRepository
    {
        public RetailAuditFormRepository(DataContext context) : base(context)
        {
        }

        public void DeleteRetailAuditForm(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RetailAuditForm> GetRetailAuditForm(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RetailAuditForm>> GetRetailAuditForms()
        {
            throw new NotImplementedException();
        }

        public Task<RetailAuditForm> InsertRetailAuditForm(RetailAuditForm retailAuditForm)
        {
            throw new NotImplementedException();
        }

        public Task<RetailAuditForm> UpdateRetailAuditForm(RetailAuditForm retailAuditForm)
        {
            throw new NotImplementedException();
        }
    }
}
