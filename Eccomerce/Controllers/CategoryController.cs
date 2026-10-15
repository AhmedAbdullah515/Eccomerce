using AutoMapper;
using Eccomerce.DTOs;
using Eccomerce.Models;
using Eccomerce.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eccomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitWork _unit;
        private readonly IMapper _mapper;
        public CategoryController(IUnitWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        [HttpGet("AllCategories")]
        public async Task<IActionResult> GetAll()
        {
            var cateogries=await _unit.CategoryRepo.GetAll();
            var result = _mapper.Map<List<CategoryDTO>>(cateogries);
            return Ok(result);
        }
        [HttpPost("CreateCategory")]
        public async Task<IActionResult>Create(CreateCategoryDTO dto)
        {
            var cateory=_mapper.Map<Category>(dto);
            await _unit.CategoryRepo.Add(cateory);
            _unit.Save();
            return Ok("Category Created Successfully");
        }
        [HttpGet("Pagination")]
        public async Task<IActionResult> Pagination(int pagenumber,int pagesize)
        {
            var categories = await _unit.CategoryRepo.Pagination(pagenumber, pagesize);
            var result=_mapper.Map<List<CategoryDTO>>(categories);
            return Ok(result);
        }
    }
}
