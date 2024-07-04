using System;
using System.Collections.Generic;
using System.Linq;
namespace Application.Commands
{
    public class DeleteCarCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public DeleteCarCommand(Guid id)
        {
            Id = id;
        }
    }
}
