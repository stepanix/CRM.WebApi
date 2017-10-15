using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Domain.Repositories
{
    public interface INoteRepository : IBaseRepository<Note>
    {
        Task<IEnumerable<Note>> GetNotes();
        Task<IEnumerable<Note>> GetNotes(DateTime dateFrom, DateTime dateTo);
        Task<IEnumerable<Note>> GetNotes(DateTime dateFrom, DateTime dateTo, string rep, int place);
        Task<IEnumerable<Note>> GetNotes(DateTime dateFrom, DateTime dateTo, string rep);
        Task<IEnumerable<Note>> GetNotes(DateTime dateFrom, DateTime dateTo, int place);
        Task<Note> GetNote(int id);
        Task<Note> InsertNote(Note note);
        IEnumerable<Note> InsertNoteList(IEnumerable<Note> notes);
        Task<Note> UpdateNote(Note note);
        void DeleteNote(int id);
    }
}
