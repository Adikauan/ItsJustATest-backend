

using ItsJustATest.Domain.Aggregates;
using ItsJustATest.Domain.Interfaces;
using ItsJustATest.Infrastructure.EntityFramework.Context;

namespace ItsJustATest.Infrastructure.EntityFramework.Repositories
{
    public class SampleRepository : BaseRepository<Sample>, ISampleRepository
    {
        public SampleRepository(SampleDbContext context) : base(context)
        {
        }
    }
}
