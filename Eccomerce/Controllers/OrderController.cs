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
    public class OrderController : ControllerBase
    {
        private readonly IUnitWork _unit;
        private readonly IMapper _mapper;
        public OrderController(IUnitWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateOrderDTO dto)
        {
            var order = _mapper.Map<Order>(dto);
            await _unit.Order.Add(order);
            _unit.Save();
            return Ok("Created");
        }
        [HttpGet("GetByid")]
        public async Task<IActionResult> GetByid(int id)
        {
            var order = await _unit.Order.GetById(id);
            if (order == null)
            {
                return NotFound("Order not found");
            }
            var result=_mapper.Map<OrderDTO>(order);
            return Ok(result);

        }
    }
}
