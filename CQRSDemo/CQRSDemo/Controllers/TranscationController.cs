using CQRSDemo.Features.TranscationFeatures.Command;
using CQRSDemo.Features.TranscationFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace CQRSDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranscationController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllTranscationsQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetTranscationByIdQuery { Id = id }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTransactionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTransactionCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteTranscationByIdCommand { Id = id }));
        }
    }
}
