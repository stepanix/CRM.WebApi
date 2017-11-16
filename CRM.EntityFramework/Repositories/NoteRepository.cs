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

        public async Task<Note> GetNote(string repoId)
        {
            return await GetDataContext()
              .Notes
              .Where(r=>r.RepoId==repoId)
              .FirstOrDefaultAsync();
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
               .Where(t => t.TenantId == user.TenantId && (DbFunctions.TruncateTime(t.AddedDate) >= dateFrom && DbFunctions.TruncateTime(t.AddedDate) <= dateTo))
               .Include(u=> u.CreatorUser)
               .Include(p=>p.Place)
               .ToListAsync();
        }

        public async Task<IEnumerable<Note>> GetNotes(DateTime dateFrom, DateTime dateTo, int place)
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();

            return await GetDataContext()
               .Notes
               .Where(t => t.TenantId == user.TenantId
               && (DbFunctions.TruncateTime(t.AddedDate) >= dateFrom && DbFunctions.TruncateTime(t.AddedDate) <= dateTo)
               && t.PlaceId == place)
               .Include(u=>u.CreatorUser)
               .Include(p=> p.Place)
               .ToListAsync();
        }

        public async Task<IEnumerable<Note>> GetNotes(DateTime dateFrom, DateTime dateTo, string rep)
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();

            return await GetDataContext()
               .Notes
               .Where(t => t.TenantId == user.TenantId
               && (DbFunctions.TruncateTime(t.AddedDate) >= dateFrom && DbFunctions.TruncateTime(t.AddedDate) <= dateTo)
               && t.CreatorUserId == rep)
               .Include(u=>u.CreatorUser)
               .Include(p=>p.Place)
               .ToListAsync();
        }

        public async Task<IEnumerable<Note>> GetNotes(DateTime dateFrom, DateTime dateTo, string rep, int place)
        {
            var user = await GetDataContext().Users.Where(u => u.Id == requestIdentityProvider.UserId).FirstOrDefaultAsync();

            return await GetDataContext()
               .Notes
               .Where(t => t.TenantId == user.TenantId
               && (DbFunctions.TruncateTime(t.AddedDate) >= dateFrom && DbFunctions.TruncateTime(t.AddedDate) <= dateTo)
               && t.CreatorUserId == rep && t.PlaceId == place)
               .Include(u=>u.CreatorUser)
               .Include(p=>p.Place)
               .ToListAsync();
        }

        public Task<Note> InsertNote(Note note)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Note> InsertNoteList(IEnumerable<Note> notes)
        {
            GetDataContext().Notes.AddRange(notes);
            return notes;
        }

        public Task<Note> UpdateNote(Note note)
        {
            throw new NotImplementedException();
        }
    }
}
