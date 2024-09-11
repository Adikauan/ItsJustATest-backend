using AutoMapper;
using MediatR;
using ItsJustATest.Domain.Aggregates;
using ItsJustATest.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItsJustATest.Application.Commands.Update
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            Sample isSampleValid = await unitOfWork.SampleRepository.GetByIdAsync(x => x.Id == request.Payload.Id);

            if (isSampleValid == null)
                return false;

            unitOfWork.SampleRepository.Update(this.mapper.Map<Sample>(request.Payload));
            bool result = await unitOfWork.Commit();

            if (!result)
            {
                unitOfWork.Rollback();
                return false;
            }
            return true;   
        }
    }
}
