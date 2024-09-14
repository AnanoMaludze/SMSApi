using Microsoft.AspNetCore.Mvc;
using SMSApi.Application.DTOs;
using SMSApi.Application.Interfaces;
using SMSApi.Domain.Interfaces;

namespace SMSApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SmsController : ControllerBase
    {
        private readonly ISmsService _smsService;
        private readonly ISmsProviderSelectorFactory _providerSelectorFactory;

        public SmsController(ISmsService smsService, ISmsProviderSelectorFactory providerSelectorFactory)
        {
            _smsService = smsService;
            _providerSelectorFactory = providerSelectorFactory;
        }

        [HttpPost("Send")]
        public async Task<IActionResult> SendSms([FromBody] SmsMessageDto messageDto, [FromQuery] string selectionLogic = "Random")
        {
            if (messageDto == null || string.IsNullOrWhiteSpace(messageDto.Phone) || string.IsNullOrWhiteSpace(messageDto.Text))
            {
                return BadRequest("Invalid SMS request.");
            }

            var providerSelector = _providerSelectorFactory.CreateSelector(selectionLogic);

            var success = await _smsService.SendMessageAsync(messageDto, selectionLogic);

            if (success)
            {
                return Ok("SMS sent successfully.");
            }
            else
            {
                return StatusCode(500, "Failed to send SMS.");
            }
        }
    }
}