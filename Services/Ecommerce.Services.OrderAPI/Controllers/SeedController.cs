using Ecommerce.Services.OrderAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Services.OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly DatabaseSeeder _seeder;
        private readonly ILogger<SeedController> _logger;

        public SeedController(DatabaseSeeder seeder, ILogger<SeedController> logger)
        {
            _seeder = seeder;
            _logger = logger;
        }

        [HttpPost("orders")]
        public async Task<IActionResult> SeedOrders([FromQuery] int count = 10000)
        {
            try
            {
                _logger.LogInformation($"Seed request received for {count} orders");

                if (count <= 0 || count > 100000)
                {
                    return BadRequest(new { error = "Count must be between 1 and 100000" });
                }

                await _seeder.SeedOrdersAsync(count);

                return Ok(new
                {
                    success = true,
                    message = $"Successfully seeded {count} orders with realistic grocery data",
                    timestamp = DateTime.UtcNow
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error seeding orders");
                return StatusCode(500, new
                {
                    error = "Failed to seed orders",
                    message = ex.Message
                });
            }
        }
    }
}
