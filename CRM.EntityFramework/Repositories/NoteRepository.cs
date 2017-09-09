using CRM.Domain.Entities;
using CRM.Domain.Repositories;
using CRM.Domain.RequestIdentity;
using CRM.EntityFramework.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;


namespace CRM.EntityFramework.Repositories
{
    public class NoteRepository : ORMBaseRepository<Note, int>, INoteRepository
    {
        IRequestIdentityProvider requestIdentityProvider;

        public NoteRepository(DataContext context, IRequestIdentityProvider requestIdentityProvider) : base(context)
        {
            this.requestIdentityProvider = requestIdentityProvider;
        }

        public void DeleteNote(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Note> GetNote(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Note>> GetNotes()
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .Notes
               .Where(t => t.TenantId == user.TenantId && t.IsDeleted == false)
               .ToListAsync();
        }

        public async Task<IEnumerable<Note>> GetNotes(DateTime dateFrom, DateTime dateTo)
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();
            return await GetDataContext()
               .Notes
               .Where(t => t.TenantId == user.TenantId && (t.AddedDate >= dateFrom && t.AddedDate <= dateTo))
               .ToListAsync();
        }

        public Task<Note> InsertNote(Note note)
        {
            throw new NotImplementedException();
        }

        public Task<Note> UpdateNote(Note note)
        {
            throw new NotImplementedException();
        }
    }
}
