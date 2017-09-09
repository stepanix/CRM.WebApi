using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CRM.Domain.Model;
using CRM.Domain.Repositories;
using AutoMapper;
using CRM.Domain.Entities;
using CRM.Domain.RequestIdentity;

namespace CRM.Service.Services.Notes
{
    public class NoteService : INoteService
    {
        INoteRepository noteRepository;
        IMapper mapper;
        IUserRepository userRepository;
        IRequestIdentityProvider requestIdentityProvider;

        public NoteService(IMapper mapper, INoteRepository noteRepository, IUserRepository userRepository, IRequestIdentityProvider requestIdentityProvider)
        {
            this.mapper = mapper;
            this.noteRepository = noteRepository;
            this.userRepository = userRepository;
            this.requestIdentityProvider = requestIdentityProvider;
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
            return mapper.Map<IEnumerable<NoteModel>>(await noteRepository.GetNotes());
        }

        public async Task<NoteModel> InsertNoteAsync(NoteModel note)
        {
            var user = await userRepository.GetUser();

            note.AddedDate = DateTime.Now;
            note.TenantId = user.TenantId;
            note.CreatorUserId = requestIdentityProvider.UserId;
            note.LastModifierUserId = requestIdentityProvider.UserId;

            var newNote = await noteRepository.InsertAsync(mapper.Map<Note>(note));
            await noteRepository.SaveChangesAsync();
            return mapper.Map<NoteModel>(newNote);
        }

        public async Task<NoteModel> UpdateNoteAsync(NoteModel note)
        {
            var user = await userRepository.GetUser();
            var noteForUpdate = await noteRepository.GetAsync(note.Id);
            noteForUpdate.ModifiedDate = DateTime.Now;
            noteForUpdate.PlaceId = note.PlaceId;
            noteForUpdate.Description = note.Description;
            noteForUpdate.TenantId = user.TenantId;
            noteForUpdate.LastModifierUserId = requestIdentityProvider.UserId;

            await noteRepository.SaveChangesAsync();
            return mapper.Map<NoteModel>(noteForUpdate);
        }

        public async Task<IEnumerable<NoteModel>> GetNotesAsync(DateTime dateFrom, DateTime dateTo)
        {
            return mapper.Map<IEnumerable<NoteModel>>(await noteRepository.GetNotes(dateFrom,dateTo));
        }
    }
}
