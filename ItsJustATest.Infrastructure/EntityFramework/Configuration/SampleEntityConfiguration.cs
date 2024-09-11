using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Sample = ItsJustATest.Domain.Aggregates.Sample;

namespace ItsJustATest.Infrastructure.EntityFramework.Configuration
{
    public class SampleEntityConfiguration : IEntityTypeConfiguration<_Sample>
    {
        public void Configure(EntityTypeBuilder<_Sample> builder)
        {
            builder.Property(x => x.Id).IsRequired();
        }
    }
}
