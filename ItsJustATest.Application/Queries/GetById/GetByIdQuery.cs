using MediatR;
using ItsJustATest.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItsJustATest.Application.Queries.GetById
{
    public class GetByIdQuery : IRequest<SampleModel>
    {
        public Guid Id { get; set; }

        public GetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
