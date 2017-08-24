using AutoMapper;
using CRM.Domain.Model;
using CRM.Domain.RequestIdentity;
using CRM.Service.Services.Notes;
using CRM.WebApi.Controllers.Base;
using CRM.WebApi.Dto.Notes.In;
using System.Threading.Tasks;
using System.Web.Http;

namespace CRM.WebApi.Controllers
{
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


    }
}