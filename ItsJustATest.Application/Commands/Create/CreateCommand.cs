using MediatR;
using ItsJustATest.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItsJustATest.Application.Commands.Create
{
    public class CreateCommand : IRequest<bool>
    {
        public SampleModel? Payload { get; set; }
    }
}
