using Microsoft.AspNetCore.Mvc;
using Shop.Api.Domain.Services;
using Shop.Api.Domain.Models;
using AutoMapper;
using Shop.Api.Domain.Services.Communication;
using System.Threading.Tasks;
using System.Collections.Generic;
using Shop.Api.Resources;
using Shop.Api.Extensions;
namespace Shop.Api.Controllers
{
    [Route("api/goods")]
    public class GoodController : Controller
    {
        private readonly IService<Good, GoodResponse> goodService;
        private readonly IMapper mapper;
        public GoodController(IService<Good,GoodResponse> service, IMapper mapper)
        {
            goodService = service;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<GoodResource>> GetAllAsync(){
            var goods = await goodService.ListAsync();
            var resource = mapper.Map<IEnumerable<Good>, IEnumerable<GoodResource>>(goods);
            return resource;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]SaveGoodResource resource){
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var good = mapper.Map<SaveGoodResource, Good>(resource);
            var result = await goodService.SaveAsync(good);
            if(!result.Success)
                return BadRequest(result.Message);
            var goodResource = mapper.Map<Good,GoodResource>(result.Good);
            return Ok(goodResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody]SaveGoodResource resource){
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
                
            var good = mapper.Map<SaveGoodResource, Good>(resource);
            var result = await goodService.UpdateAsync(id, good);
            if(!result.Success)
                return BadRequest(result.Message);
            var goodResource = mapper.Map<Good,GoodResource>(result.Good);
            return Ok(goodResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id){
            var result = await goodService.DeleteAsync(id);
            if(!result.Success)
                return BadRequest(result.Message);
            var resource = mapper.Map<Good, GoodResource>(result.Good);
            return Ok(resource);
        }
    }
}