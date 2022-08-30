using AutoMapper;
using CRUD.Application.Commands.ClientCommands;
using CRUD.Application.Mapper;
using CRUD.Application.Response;
using CRUD.Core.Entities;
using CRUD.Core.Repositories.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.Handler.CommandHandlers.ClientCommandHandlers
{
    // Client create command handler with ClientResponse as output
    public class CreateClientHandler : IRequestHandler<CreateClientCommand, ClientResponse>
    {
        private readonly IClientCommandRepository _clientCommandRepository;
        private readonly IMapper _mapper;

        public CreateClientHandler(IClientCommandRepository clientCommandRepository, IMapper mapper)
        {
            _clientCommandRepository = clientCommandRepository;
            _mapper = mapper;
        }

        public async Task<ClientResponse> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var customerEntity = _mapper.Map<Client>(request);

            if (customerEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            var newCustomer = await _clientCommandRepository.AddAsync(customerEntity);
            var customerResponse = _mapper.Map<ClientResponse>(newCustomer);
            return customerResponse;
        }
    }
}
