using AutoMapper;
using MediatR;
using ItsJustATest.Application.Models;
using ItsJustATest.Domain.Aggregates;
using ItsJustATest.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItsJustATest.Application.Queries.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, SampleModel>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<SampleModel> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            => this.mapper.Map<SampleModel>(await this.unitOfWork.SampleRepository.GetByIdAsync(x => x.Id == request.Id));
    }
}
