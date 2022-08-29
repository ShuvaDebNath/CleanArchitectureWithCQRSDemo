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
    public class GetClientByClientTypeHandler : IRequestHandler<GetClientByClientTypeQuery, Client>
    {
        private readonly IMediator _mediator;
        public GetClientByClientTypeHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Client> Handle(GetClientByClientTypeQuery request, CancellationToken cancellationToken)
        {
            var client = await _mediator.Send(new GetAllClientQuery());
            var selectedClientByClientType = client.FirstOrDefault(x => x.ClientType == request.ClientType);
            return selectedClientByClientType;
        }
    }
}
