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
    public class ProductController : ControllerBase
    {
        private readonly IUnitWork _unit;
        private readonly IMapper _mapper;

        public ProductController(IUnitWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        [HttpGet("GetByid")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _unit.ProductRepo.GetById(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }
            var result = _mapper.Map<ProductDTO>(product);
            return Ok(result);
        }
        [HttpGet("Filter")]
        public async Task<IActionResult> Filter()
        {
            var product = await _unit.ProductRepo.filterProducts();
            var result = _mapper.Map<ProductDTO>(product);
            return Ok(result);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateProductDTO dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _unit.ProductRepo.Add(product);
            _unit.Save();
            return Ok("Created succesfully");


        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, UpdateProductDTO dto)
        {
            var product = await _unit.ProductRepo.GetById(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }
            _mapper.Map(dto, product);
            _unit.Save();
            return Ok("updated");
        }
        [HttpPatch("UpdateStock")]
        public async Task<IActionResult> UpdateStock(int id, UpdateProductDTO dto)
        {
            var product = await _unit.ProductRepo.GetById(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }
            product.StockQuantity = dto.StockQuantity;
            _unit.Save();
            return Ok("Stock updated");
        }
        [HttpGet("searchByName")]
        public async Task<IActionResult> SearchByName(string Name)
        {
            var product = await _unit.ProductRepo.SearchByname(Name);
            if (product == null)
            {
                return NotFound("Product not found");
            }
            var result=_mapper.Map<ProductDTO>(product);
            return Ok(result);
        }

    }
}
