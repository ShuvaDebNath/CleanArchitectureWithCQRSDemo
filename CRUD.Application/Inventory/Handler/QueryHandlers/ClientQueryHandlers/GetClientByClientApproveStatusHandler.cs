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
    public class GetClientByClientApproveStatusHandler : IRequestHandler<GetClientByClientApproveStatusQuery, Client?>
    {

        private readonly IMediator _mediator;
        public GetClientByClientApproveStatusHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Client?> Handle(GetClientByClientApproveStatusQuery request, CancellationToken cancellationToken)
        {
            var client = await _mediator.Send(new GetAllClientQuery());
            var selectedClientByClientApproveStatus = client.FirstOrDefault(x => x.ClientApproveStatus == request.ClientApproveStatus);
            return selectedClientByClientApproveStatus;
        }
    }
}
