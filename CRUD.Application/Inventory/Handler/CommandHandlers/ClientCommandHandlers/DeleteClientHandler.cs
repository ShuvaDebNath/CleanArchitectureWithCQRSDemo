using CRUD.Application.Commands.ClientCommands;
using CRUD.Core.Repositories.Command;
using CRUD.Core.Repositories.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.Handler.CommandHandlers.ClientCommandHandlers
{
    // Client delete command handler with string response as output
    public class DeleteClientHandler : IRequestHandler<DeleteClientCommand, String>
    {
        private readonly IClientCommandRepository _clientCommandRepository;
        private readonly IClientQueryRepository _clientQueryRepository;

        public DeleteClientHandler(IClientCommandRepository clientCommandRepository, IClientQueryRepository clientQueryRepository)
        {
            _clientCommandRepository = clientCommandRepository;
            _clientQueryRepository = clientQueryRepository;
        }

        public async Task<string> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customerEntity = await _clientQueryRepository.GetByIdAsync(request.ClinetId);

                await _clientCommandRepository.DeleteAsync(customerEntity);
            }
            catch (Exception exp)
            {
                throw (new ApplicationException(exp.Message));
            }

            return "Customer information has been deleted!";
        }
    }
}
