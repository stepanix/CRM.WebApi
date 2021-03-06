﻿using CRM.Domain.Entities;
using CRM.Domain.Repositories;
using CRM.EntityFramework.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using CRM.Domain.RequestIdentity;

namespace CRM.EntityFramework.Repositories
{
    public class RetailAuditFormRepository : ORMBaseRepository<RetailAuditForm, int>, IRetailAuditFormRepository
    {
        IRequestIdentityProvider requestIdentityProvider;
        public RetailAuditFormRepository(DataContext context, IRequestIdentityProvider requestIdentityProvider) : base(context)
        {
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public void DeleteRetailAuditForm(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RetailAuditForm> GetRetailAuditForm(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RetailAuditForm>> GetRetailAuditForms()
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .RetailAuditForms
               .Where(t => t.TenantId == user.TenantId && t.IsDeleted == false)
               .ToListAsync();
        }

        public async Task<IEnumerable<RetailAuditForm>> GetRetailAuditForms(DateTime dateFrom, DateTime dateTo)
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .RetailAuditForms
               .Where(t => t.TenantId == user.TenantId && (t.AddedDate >= dateFrom && t.AddedDate <= dateTo))
               .ToListAsync();
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
