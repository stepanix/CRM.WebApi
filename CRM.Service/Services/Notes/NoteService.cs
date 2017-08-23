using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.Model;
using CRM.Domain.Repositories;
using AutoMapper;
using CRM.Domain.Entities;

namespace CRM.Service.Services.Notes
{
    public class NoteService : INoteService
    {
        INoteRepository noteRepository;
        IMapper mapper;

        public NoteService(IMapper mapper, INoteRepository noteRepository)
        {
            this.mapper = mapper;
            this.noteRepository = noteRepository;
        }


        public void DeleteNote(int id)
        {
            noteRepository.Delete(id);
        }

        public async Task<NoteModel> GetNoteAsync(int id)
        {
            return mapper.Map<NoteModel>(await noteRepository.GetAsync(id));
        }

        public async Task<IEnumerable<NoteModel>> GetNotesAsync()
        {
            return mapper.Map<IEnumerable<NoteModel>>(await noteRepository.GetAllAsync());
        }

        public async Task<NoteModel> InsertNoteAsync(NoteModel note)
        {
            note.AddedDate = DateTime.Now;
            var newNote = await noteRepository.InsertAsync(mapper.Map<Note>(note));
            await noteRepository.SaveChangesAsync();
            return mapper.Map<NoteModel>(newNote);
        }

        public async Task<NoteModel> UpdateNoteAsync(NoteModel note)
        {
            var noteForUpdate = await noteRepository.GetAsync(note.Id);
            noteForUpdate.ModifiedDate = DateTime.Now;
            noteForUpdate.PlaceId = note.PlaceId;
            noteForUpdate.Description = note.Description;           

            await noteRepository.SaveChangesAsync();
            return mapper.Map<NoteModel>(noteForUpdate);
        }
    }
}
