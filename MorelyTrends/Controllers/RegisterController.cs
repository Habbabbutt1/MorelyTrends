using MediatR;
using Microsoft.AspNetCore.Mvc;
using MorelyTrends.Application.Commands;
using MorelyTrends.Application.DTOs;
using MorelyTrends.Domain.Entities;

namespace MorelyTrends.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ISender _sender;
        public RegisterController(ILogger<WeatherForecastController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> AddSeller(CreateEditSellerDto seller)
        {
            var result = await _sender.Send(new AddSellerCommand(seller));
            return Ok(result);
        }
    }
}
