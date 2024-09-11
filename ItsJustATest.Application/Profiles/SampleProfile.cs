using AutoMapper;
using ItsJustATest.Application.Models;
using ItsJustATest.Domain.Aggregates;

namespace ItsJustATest.Application.Profiles
{
    public class SampleProfile : Profile
    {
        public SampleProfile()
        {
            base.CreateMap<Sample, SampleModel>()
                .ReverseMap();

        }
    }
}
