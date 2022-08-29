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

    public class GetClientByBinNumberHandler : IRequestHandler<GetClientByBinNumberQuery, Client>
    {
        private readonly IMediator _mediator;
        public GetClientByBinNumberHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Client> Handle(GetClientByBinNumberQuery request, CancellationToken cancellationToken)
        {
            var client = await _mediator.Send(new GetAllClientQuery());
            var selectedClientByBinNumber = client.FirstOrDefault(x => x.Bin_No == request.Bin_No);
            return selectedClientByBinNumber;
        }
    }
}
