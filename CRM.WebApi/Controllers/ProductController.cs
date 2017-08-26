

using CRM.WebApi.Controllers.Base;
using System.Web.Http;
using CRM.Domain.RequestIdentity;
using CRM.Service.Services.Products;
using AutoMapper;
using CRM.Domain.Model;
using System.Threading.Tasks;

namespace CRM.WebApi.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : BaseController
    {
        IProductService productService;
        IMapper mapper;

        public ProductController(IMapper mapper, IProductService productService, IRequestIdentityProvider requestIdentityProvider) : base(requestIdentityProvider)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create([FromBody]ProductModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await productService.InsertProductAsync(product);
            return Ok(created);
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> Update([FromBody]ProductModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await productService.UpdateProductAsync(product);
            return Ok(created);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> Read(int id)
        {
            var created = await productService.GetProductAsync(id);
            return Ok(created);
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> ReadAll()
        {
            var created = await productService.GetProductsAsync();
            return Ok(created);
        }


    }
}