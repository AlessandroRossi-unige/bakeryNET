using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [EnableCors]
    public class SweetsController : BaseApiController
    {
        private readonly ISweetsService _sweetsService;
        private readonly IGenericRepository<Sweet> _sweetsRepo;
        private readonly IMapper _mapper;
        
        public SweetsController(ISweetsService sweetsService, IMapper mapper, IGenericRepository<Sweet> sweetsRepo)
        {
            _sweetsService = sweetsService;
            _mapper = mapper;
            _sweetsRepo = sweetsRepo;
        }

        [HttpPost("add")]
        public async Task<ActionResult<SweetToReturnDto>> AddSweet(SweetsDto sweet)
        {
            try
            {
                var result =  await  _sweetsService.CreateSweetAsync(sweet.Name, sweet.Price, sweet.Description, sweet.Ingredients, sweet.PictureUrl);
            
                return _mapper.Map<Sweet, SweetToReturnDto>(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<SweetToReturnDto>> DeleteSweet(int id)
        {
            try
            {
                var result =  await  _sweetsService.DeleteSweetAsync(id);
                if (result == null) NotFound(new ApiResponse(404));
                return _mapper.Map<Sweet, SweetToReturnDto>(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<SweetToReturnDto>>> GetAllSweets([FromQuery]SweetSpecParam sweetParams)
        {
            var spec = new SweetsWithIngredientsSpecification(sweetParams);
            var sweets = await _sweetsRepo.ListAllAsync(spec);
            var totalItems = await _sweetsRepo.CountAsync();
             //var sweets2 = await _sweetsService.GetSweetsAsync();
            var data = _mapper.Map<IReadOnlyList<Sweet>, IReadOnlyList<SweetToReturnDto>>(sweets);
            return Ok(new Pagination<SweetToReturnDto>(sweetParams.PageIndex, sweetParams.PageSize, totalItems, data));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<SweetToReturnDto>> GetSweetById(int id)
        {
            var spec = new SweetsWithIngredientsSpecification(id);
            var sweet = await _sweetsRepo.GetEntityWithSpec(spec);
            
            if (sweet == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(_mapper.Map<Sweet, SweetToReturnDto>(sweet));
        }
    }
}