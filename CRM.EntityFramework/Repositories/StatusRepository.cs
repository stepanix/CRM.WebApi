using CRM.Domain.Entities;
using CRM.Domain.Repositories;
using CRM.EntityFramework.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.EntityFramework.Repositories
{
    public class StatusRepository : ORMBaseRepository<Status, int>, IStatusRepository
    {
        public StatusRepository(DataContext context) : base(context)
        {
        }

        public void DeleteStatus(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Status> GetStatus(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Status>> GetStatuses()
        {
            throw new NotImplementedException();
        }

        public Task<Status> InsertStatus(Status status)
        {
            throw new NotImplementedException();
        }

        public Task<Status> UpdateStatus(Status status)
        {
            throw new NotImplementedException();
        }
    }
}
