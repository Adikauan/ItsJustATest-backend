using MediatR;
using Microsoft.AspNetCore.Mvc;
using ItsJustATest.Application.Commands.Create;
using ItsJustATest.Application.Commands.Delete;
using ItsJustATest.Application.Commands.Update;
using ItsJustATest.Application.Models;
using ItsJustATest.Application.Queries.GetById;
using ItsJustATest.Application.Queries.GettAll;
using ItsJustATest.Domain.Interfaces;

namespace ItsJustATest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMediator mediator;

        public SampleController(IUnitOfWork unitOfWork, IMediator mediator)
        {
            this.unitOfWork = unitOfWork;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<SampleModel>> GetAll() => await this.mediator.Send(new GetAllQuery());

        [HttpGet("{id}")]
        public async Task<SampleModel> GetById(Guid id) => await this.mediator.Send(new GetByIdQuery(id));

        [HttpPost]
        public async Task<bool> Post(CreateCommand command) => await this.mediator.Send(command);

        [HttpPut]
        public async Task<bool> Update(UpdateCommand command) => await this.mediator.Send(command);

        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id) => await this.mediator.Send(new DeleteCommand(id));
    }
}
