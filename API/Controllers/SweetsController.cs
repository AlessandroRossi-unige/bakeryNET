using System;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SweetsController : BaseApiController
    {
        private readonly ISweetsService _sweetsService;
        private readonly IMapper _mapper;
        
        public SweetsController(ISweetsService sweetsService, IMapper mapper)
        {
            _sweetsService = sweetsService;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public async Task<ActionResult<SweetToReturnDto>> AddSweet(SweetsDto sweet)
        {
            try
            {
                var result =  await  _sweetsService.CreateSweetAsync(sweet.Name, sweet.Price, sweet.Ingredients);
            
                return _mapper.Map<Sweet, SweetToReturnDto>(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<Sweet>> GetAllSweets()
        {
            var sweets = await _sweetsService.GetSweetsAsync();
            return Ok(sweets);
        }
    }
}