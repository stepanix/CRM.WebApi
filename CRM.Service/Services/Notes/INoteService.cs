using CRM.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Service.Services.Notes
{
    public interface INoteService
    {
        Task<IEnumerable<NoteModel>> GetNotesAsync();
        Task<NoteModel> GetNoteAsync(int id);
        Task<NoteModel> InsertNoteAsync(NoteModel note);
        Task<NoteModel> UpdateNoteAsync(NoteModel note);
        void DeleteNote(int id);
    }
}
