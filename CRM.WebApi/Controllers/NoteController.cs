using AutoMapper;
using CRM.Domain.Model;
using CRM.Domain.RequestIdentity;
using CRM.Service.Services.Notes;
using CRM.WebApi.Controllers.Base;
using CRM.WebApi.Dto.Notes.In;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace CRM.WebApi.Controllers
{
    [RoutePrefix("api/Note")]
    public class NoteController : BaseController
    {

        INoteService noteService;
        IMapper mapper;

        public NoteController(INoteService noteService,IMapper mapper,IRequestIdentityProvider requestIdentityProvider) : base(requestIdentityProvider)
        {
            this.noteService = noteService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody]NoteDtoIn note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await noteService.InsertNoteAsync(mapper.Map<NoteModel>(note));
            return Ok(created);
        }

        [HttpPost]
        [Route("List")]
        public async Task<IHttpActionResult> CreateList([FromBody]IEnumerable<NoteDtoIn> notes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await noteService.InsertNoteListAsync(mapper.Map<IEnumerable<NoteModel>>(notes));
            return Ok(created);
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> Update([FromBody]NoteDtoIn note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await noteService.UpdateNoteAsync(mapper.Map<NoteModel>(note));
            return Ok(created);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Read(int id)
        {
            var created = await noteService.GetNoteAsync(id);
            return Ok(created);
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> ReadAll()
        {
            var created = await noteService.GetNotesAsync();
            return Ok(created);
        }

        [HttpGet]
        [Route("DateRange")]
        public async Task<IHttpActionResult> ReadAllByDateRange(DateTime dateFrom,DateTime dateTo)
        {
            var created = await noteService.GetNotesAsync(dateFrom,dateTo);
            return Ok(created);
        }

        [HttpGet]
        [Route("Rep")]
        public async Task<IHttpActionResult> ReadAllByRep(DateTime dateFrom, DateTime dateTo, string rep)
        {
            var created = await noteService.GetNotesAsync(dateFrom, dateTo,rep);
            return Ok(created);
        }

        [HttpGet]
        [Route("Place")]
        public async Task<IHttpActionResult> ReadAllByPlace(DateTime dateFrom, DateTime dateTo, int place)
        {
            var created = await noteService.GetNotesAsync(dateFrom, dateTo, place);
            return Ok(created);
        }

        [HttpGet]
        [Route("RepAndPlace")]
        public async Task<IHttpActionResult> ReadAllByRepAndPlace(DateTime dateFrom, DateTime dateTo, string rep, int place)
        {
            var created = await noteService.GetNotesAsync(dateFrom, dateTo, rep, place);
            return Ok(created);
        }


        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            noteService.DeleteNote(id);
            return Ok("");
        }


    }
}