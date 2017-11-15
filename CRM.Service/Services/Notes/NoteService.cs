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
            note.RepoId = note.RepoId;
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
            noteForUpdate.ScheduleId = note.ScheduleId;
            noteForUpdate.Description = note.Description;
            noteForUpdate.TenantId = user.TenantId;
            noteForUpdate.LastModifierUserId = requestIdentityProvider.UserId;
            noteForUpdate.RepoId = note.RepoId;
            await noteRepository.SaveChangesAsync();
            return mapper.Map<NoteModel>(noteForUpdate);
        }

        public async Task<IEnumerable<NoteModel>> GetNotesAsync(DateTime dateFrom, DateTime dateTo)
        {
            return mapper.Map<IEnumerable<NoteModel>>(await noteRepository.GetNotes(dateFrom,dateTo));
        }

        public async Task<IEnumerable<NoteModel>> GetNotesAsync(DateTime dateFrom, DateTime dateTo, string rep)
        {
            return mapper.Map<IEnumerable<NoteModel>>(await noteRepository.GetNotes(dateFrom, dateTo,rep));
        }

        public async Task<IEnumerable<NoteModel>> GetNotesAsync(DateTime dateFrom, DateTime dateTo, int place)
        {
            return mapper.Map<IEnumerable<NoteModel>>(await noteRepository.GetNotes(dateFrom, dateTo, place));
        }

        public async Task<IEnumerable<NoteModel>> GetNotesAsync(DateTime dateFrom, DateTime dateTo, string rep, int place)
        {
            return mapper.Map<IEnumerable<NoteModel>>(await noteRepository.GetNotes(dateFrom, dateTo, rep, place));
        }

        public async Task<IEnumerable<NoteModel>> InsertNoteListAsync(IEnumerable<NoteModel> notes)
        {
            var user = await userRepository.GetUser();

            List<NoteModel> noteList = new List<NoteModel>();

            foreach (var note in notes)
            {
                var noteVar = new NoteModel
                {
                    SyncId = note.SyncId,
                    PlaceId = note.PlaceId,
                    ScheduleId = note.ScheduleId,
                    Description = note.Description,                    
                    AddedDate = DateTime.Now,
                    TenantId = user.TenantId,
                    CreatorUserId = requestIdentityProvider.UserId,
                    LastModifierUserId = requestIdentityProvider.UserId,
                    RepoId = note.RepoId,
                };
                noteList.Add(noteVar);
            }
            var newNoteList = noteRepository.InsertNoteList(mapper.Map<IEnumerable<Note>>(noteList));
            await noteRepository.SaveChangesAsync();
            return noteList;
        }
    }
}
