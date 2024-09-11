using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItsJustATest.Application.Commands.Delete
{
    public class DeleteCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteCommand(Guid id)
        {
            Id = id;
        }
    }
}
