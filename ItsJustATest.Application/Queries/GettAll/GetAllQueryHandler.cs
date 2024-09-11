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

namespace ItsJustATest.Application.Queries.GettAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<SampleModel>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SampleModel>> Handle(GetAllQuery request, CancellationToken cancellationToken)
            => this.mapper.Map<IEnumerable<SampleModel>>(await unitOfWork.SampleRepository.GetAllAsync());

    }
}
