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
    public class GetClientByLedgerUnapproveStatusHandler : IRequestHandler<GetClientByLedgerUnapproveStatusQuery, Client>
    {
        private readonly IMediator _mediator;
        public GetClientByLedgerUnapproveStatusHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Client> Handle(GetClientByLedgerUnapproveStatusQuery request, CancellationToken cancellationToken)
        {
            var client = await _mediator.Send(new GetAllClientQuery());
            var selectedClientByLedgerUnapproveStatus = client.FirstOrDefault(x => x.LedgerApproveStatus == request.LedgerApproveStatus);
            return selectedClientByLedgerUnapproveStatus;
        }
    }
}
