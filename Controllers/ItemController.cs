using item_api.DTOs;
using item_api.Models;
using item_api.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace item_api.Controllers
{
    [ApiController]
    [Route("api/item")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<ItemController> _logger;

        public ItemController(IItemService service, IMapper mapper,ILogger<ItemController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<ItemDto>>> Get(int page = 1, int pageSize = 10)
        {
            _logger.LogInformation("Fetching items page {Page}", page);
            var items = await _service.GetPagedAsync(page, pageSize);

            var result = _mapper.Map<List<ItemDto>>(items);

            return Ok(new ApiResponse<List<ItemDto>>
            {
                Success = true,
                Data = result,
                Message = "Items retrieved"
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> Get(int id)
        {
            var item = await _service.GetByIdAsync(id);

            if (item == null) return NotFound();

            var result = _mapper.Map<ItemDto>(item);

            return Ok(new ApiResponse<ItemDto>
            {
                Success = true,
                Data = result,
                Message = "Item retriverd"
            });
        }

        [HttpGet("search")]
        public async Task<ActionResult> Search(string name)
        {
            _logger.LogInformation("Searching items with name {Name}", name);

            var items = await _service.SearchAsync(name);

            var result = _mapper.Map<List<ItemDto>>(items);

            return Ok(new ApiResponse<List<ItemDto>>
            {
                Success = true,
                Data = result,
                Message = "Search completed"
            }
                );
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ApiResponse<ItemDto>>> Post(CreateItemDto dto)
        {
            var item = _mapper.Map<Item>(dto);

            var created = await _service.CreateAsync(item);

            var result = _mapper.Map<ItemDto>(created);

            return CreatedAtAction(
                nameof(Get),
                new { id = result.Id },
                new ApiResponse<ItemDto>
                {
                    Success = true,
                    Data = result,
                    Message = "Item created"
                }
                );
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<ItemDto>>> Put(int id, UpdateItemDto dto)
        {
            var item = _mapper.Map<Item>(dto);

            var updatedItem = await _service.UpdateAsync(id, item);

            if (updatedItem == null) return NotFound();

            var result = _mapper.Map<ItemDto>(updatedItem);

            return Ok(new ApiResponse<ItemDto>
            {
                Success = true,
                Data = result,
                Message = "Item updated"
            });
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result) return NotFound();

            return NoContent();
        }
    }
}