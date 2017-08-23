using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Repositories
{
    public interface INoteRepository : IBaseRepository<Note>
    {
        Task<IEnumerable<Note>> GetNotes();
        Task<Note> GetNote(int id);
        Task<Note> InsertNote(Note note);
        Task<Note> UpdateNote(Note note);
        void DeleteNote(int id);
    }
}
