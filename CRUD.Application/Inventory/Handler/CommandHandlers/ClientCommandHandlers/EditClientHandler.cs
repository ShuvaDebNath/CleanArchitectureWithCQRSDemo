using AutoMapper;
using CRUD.Application.Commands.ClientCommands;
using CRUD.Application.Mapper;
using CRUD.Application.Response;
using CRUD.Core.Entities;
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
    // Client edit command handler with client response as output
    public class EditClientHandler : IRequestHandler<EditClientCommand, ClientResponse>
    {
        private readonly IClientCommandRepository _clientCommandRepository;
        private readonly IClientQueryRepository _clientQueryRepository;
        private readonly IMapper _mapper;

        public EditClientHandler
            (IClientCommandRepository clientCommandRepository, 
            IClientQueryRepository clientQueryRepository, IMapper mapper)
        {
            _clientCommandRepository = clientCommandRepository;
            _clientQueryRepository = clientQueryRepository;
            _mapper = mapper;
        }

        public async Task<ClientResponse> Handle(EditClientCommand request, CancellationToken cancellationToken)
        {
            var customerEntity = _mapper.Map<Client>(request);

            if (customerEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            try
            {
                await _clientCommandRepository.UpdateAsync(customerEntity);
            }
            catch (Exception exp)
            {
                throw new ApplicationException(exp.Message);
            }

            var modifiedCustomer = await _clientQueryRepository.GetByIdAsync(request.ClinetId);
            var customerResponse = _mapper.Map<ClientResponse>(modifiedCustomer);

            return customerResponse;
        }
    }
}
