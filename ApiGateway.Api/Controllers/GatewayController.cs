using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Api.Controllers
{
    [Route("api/gateway")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            return Ok(new
            {
                message = "API Gateway is running",
                time = DateTime.UtcNow
            });
        }

        [HttpGet("routes")]
        public IActionResult GetAvailableRoutes()
        {
            return Ok(new[]
            {
                "/api/auth",
                "/api/customers",
                "/inventories",
                "/api/orders",
                "/api/payments",
                "/api/products",
                "/api/reports"
            });
        }
    }
}
