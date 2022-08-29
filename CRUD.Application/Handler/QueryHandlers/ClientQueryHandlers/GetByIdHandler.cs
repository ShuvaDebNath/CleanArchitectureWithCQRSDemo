using CRUD.Application.Queries.ClientQueries;
using CRUD.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.Handler.QueryHandlers.ClientQueryHandlers
{
    // Get specific query handler with Client response as output
    public class GetByIdHandler : IRequestHandler<GetByIdQuery, Client>
    {
        private readonly IMediator _mediator;
        public GetByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Client> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var client = await _mediator.Send(new GetAllClientQuery());
            var selectedClient = client.FirstOrDefault(x => x.ClinetId == request.ClinetId);
            return selectedClient;
        }
    }
}
