using MediatR;
using ItsJustATest.Domain.Aggregates;
using ItsJustATest.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItsJustATest.Application.Commands.Delete
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            Sample isSampleValid = await unitOfWork.SampleRepository.GetByIdAsync(x => x.Id == request.Id);

            if(isSampleValid == null)
                return false;

            unitOfWork.SampleRepository.Remove(isSampleValid);
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
