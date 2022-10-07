using API.DTOs.Items;
using API.Services.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Inventory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryService _service;
        private readonly ILogger<InventoryController> _logger;

        public InventoryController(ILogger<InventoryController> logger
            , InventoryService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetItemRequest request)
        {
            var items = await _service.SearchAsync(request);

            if (items == null)
            {
                return NotFound(request);
            }
            else
            {
                if (!string.IsNullOrEmpty(items.ErrorMessage))
                {
                    return BadRequest(items.ErrorMessage);
                }
                else
                {
                    return Ok(items);
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddUserRequest request)
        {
            var users = await _service.AddNewAsync(request);
            return Ok(users);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllItems()
        {
            var users = await _service.GetAllItems();
            return Ok(users);
        }
    }
}
