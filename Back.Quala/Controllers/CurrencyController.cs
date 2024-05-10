using Application.CQRS.Queries.Currency;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Back.Quala.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CurrencyController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllCurrencyQuery()));
        }
    }
}
