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
    public class GetClientByClientReferenceHandler : IRequestHandler<GetClientByClientReferenceQuery, Client>
    {
        private readonly IMediator _mediator;
        public GetClientByClientReferenceHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Client> Handle(GetClientByClientReferenceQuery request, CancellationToken cancellationToken)
        {
            var client = await _mediator.Send(new GetAllClientQuery());
            var selectedClientByClientReference = client.FirstOrDefault(x => x.ClientReference == request.ClientReference);
            return selectedClientByClientReference;
        }
    }
}
