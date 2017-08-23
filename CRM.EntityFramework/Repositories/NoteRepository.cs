using CRM.Domain.Entities;
using CRM.Domain.Repositories;
using CRM.EntityFramework.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.EntityFramework.Repositories
{
    public class NoteRepository : ORMBaseRepository<Note, int>, INoteRepository
    {
        public NoteRepository(DataContext context) : base(context)
        {
        }

        public void DeleteNote(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Note> GetNote(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Note>> GetNotes()
        {
            throw new NotImplementedException();
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
