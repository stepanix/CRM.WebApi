using CRM.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Service.Services.Notes
{
    public interface INoteService
    {
        Task<IEnumerable<NoteModel>> GetNotesAsync();
        Task<IEnumerable<NoteModel>> GetNotesAsync(DateTime dateFrom, DateTime dateTo);
        Task<NoteModel> GetNoteAsync(int id);
        Task<NoteModel> InsertNoteAsync(NoteModel note);
        Task<NoteModel> UpdateNoteAsync(NoteModel note);
        void DeleteNote(int id);
    }
}
