using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SweetsController : BaseApiController
    {
        private readonly ISweetsService _sweetsService;
        
        public SweetsController(ISweetsService sweetsService)
        {
            _sweetsService = sweetsService;
        }

        [HttpPost("add")]
        public async Task<ActionResult<Sweet>> AddSweet(Sweet sweet)
        {
            var result =  await  _sweetsService.CreateSweetAsync(sweet.Name, sweet.Price);
            
            return Ok(result);
        }
    }
}