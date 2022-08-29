using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.Commands.ClientCommands
{
    // Client create command with string response
    public class DeleteClientCommand : IRequest<String>
    {
        public string ClinetId { get; private set; }

        public DeleteClientCommand(String ClinetId)
        {
            this.ClinetId = ClinetId;
        }
    }
}
