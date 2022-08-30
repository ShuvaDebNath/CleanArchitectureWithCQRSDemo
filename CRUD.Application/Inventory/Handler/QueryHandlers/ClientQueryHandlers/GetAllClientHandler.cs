using CRUD.Application.Queries.ClientQueries;
using CRUD.Core.Entities;
using CRUD.Core.Repositories.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.Handler.QueryHandlers.ClientQueryHandlers
{
    // Get all client query handler with List<Client> response as output
    public class GetAllClientHandler : IRequestHandler<GetAllClientQuery, List<Client>>
    {
        private readonly IClientQueryRepository _clientQueryRepository;

        public GetAllClientHandler(IClientQueryRepository clientQueryRepository)
        {
            _clientQueryRepository = clientQueryRepository;
        }

        public async Task<List<Client>> Handle(GetAllClientQuery request, CancellationToken cancellationToken)
        {
            return (List<Client>)await _clientQueryRepository.GetAllAsync();
        }
    }
}
