using AutoMapper;
using MediatR;
using ItsJustATest.Domain.Aggregates;
using ItsJustATest.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItsJustATest.Application.Commands.Create
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            Sample sampleModel = this.mapper.Map<Sample>(request.Payload);
            this.unitOfWork.SampleRepository.Add(sampleModel);
            var result = await this.unitOfWork.Commit();

            if (!result)
            {
                unitOfWork.Rollback();
                return false;
            }

            return true;
        }
    }
}
