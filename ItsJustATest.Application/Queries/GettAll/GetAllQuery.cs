using MediatR;
using ItsJustATest.Application.Models;
using ItsJustATest.Domain.Aggregates;

namespace ItsJustATest.Application.Queries.GettAll
{
    public class GetAllQuery : IRequest<IEnumerable<SampleModel>>
    {
    }
}
