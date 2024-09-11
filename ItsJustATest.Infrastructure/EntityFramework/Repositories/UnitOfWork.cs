using ItsJustATest.Domain.Interfaces;
using ItsJustATest.Infrastructure.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItsJustATest.Infrastructure.EntityFramework.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly SampleDbContext context;
        public ISampleRepository? sampleRepository;

        public UnitOfWork(SampleDbContext context, ISampleRepository? sampleRepository)
        {
            this.context = context;
            this.sampleRepository = sampleRepository;
        }

        public ISampleRepository SampleRepository => sampleRepository ?? (new SampleRepository(context));

        public async Task<bool> Commit()
        {
            var result = await context.SaveChangesAsync();

            if (result == 0)
                return false;
            return true;

        }

        public void Rollback()
        {
            context?.Dispose();
        }
    }
}
