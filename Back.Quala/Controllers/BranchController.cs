using Application.CQRS.Commands.Branch;
using Application.CQRS.Queries.Branch;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back.Quala.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BranchController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateBranchCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetByCode), new { code = result.Data?.Code }, result);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Put(int code, UpdateBranchCommand command)
        {            
            command.Code = code;
            return Ok(await _mediator.Send(command));
        }


        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(int code)
        {
            return Ok(await _mediator.Send(new DeleteBranchCommand { Code = code}));
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(int code)
        {
            return Ok(await _mediator.Send(new GetByCodeBranchQuery { Code = code }));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllBranchQuery()));
        }

    }


}
