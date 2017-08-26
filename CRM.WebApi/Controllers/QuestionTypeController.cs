
using CRM.WebApi.Controllers.Base;
using System.Web.Http;
using CRM.Domain.RequestIdentity;
using CRM.Service.Services.QuestionTypes;
using AutoMapper;
using CRM.Domain.Model;
using System.Threading.Tasks;

namespace CRM.WebApi.Controllers
{
    [RoutePrefix("api/QuestionType")]
    public class QuestionTypeController : BaseController
    {
        IQuestionTypeService questionTypeService;
        IMapper mapper;

        public QuestionTypeController(IMapper mapper, IQuestionTypeService questionTypeService, IRequestIdentityProvider requestIdentityProvider) : base(requestIdentityProvider)
        {
            this.questionTypeService = questionTypeService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody]QuestionTypeModel questionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await questionTypeService.InsertQuestionTypeAsync(questionType);
            return Ok(created);
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> Update([FromBody]QuestionTypeModel questionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await questionTypeService.UpdateQuestionTypeAsync(questionType);
            return Ok(created);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Read(int id)
        {
            var created = await questionTypeService.GetQuestionTypeAsync(id);
            return Ok(created);
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> ReadAll()
        {
            var created = await questionTypeService.GetQuestionTypesAsync();
            return Ok(created);
        }

    }
}