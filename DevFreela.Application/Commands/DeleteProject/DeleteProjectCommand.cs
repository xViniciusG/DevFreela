using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.DeleteProject
{
    public class DeleteProjectCommand : IRequest<Unit>
    {
        public DeleteProjectCommand(int id)
        {
            this.id = id;
        }

        public int id { get; set; }

    }
}
