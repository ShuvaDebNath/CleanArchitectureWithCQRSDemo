using CRUD.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.Queries.ClientQueries
{
    public class GetClientByClientTypeQuery : IRequest<Client>
    {
        public string ClientType { get; private set; }

        public GetClientByClientTypeQuery(string ClientType)
        {
            this.ClientType = ClientType;
        }
    }
}
