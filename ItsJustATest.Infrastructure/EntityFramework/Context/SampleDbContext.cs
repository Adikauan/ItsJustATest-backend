using Microsoft.EntityFrameworkCore;
using ItsJustATest.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItsJustATest.Infrastructure.EntityFramework.Context
{
    public class SampleDbContext : DbContext
    {
        DbSet<Sample> Samples { get; set; } 

        public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
        {
        }
    }
}
