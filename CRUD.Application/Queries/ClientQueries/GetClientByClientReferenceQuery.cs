using CRUD.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.Queries.ClientQueries
{
    public class GetClientByClientReferenceQuery : IRequest<Client>
    {
        public string ClientReference { get; private set; }

        public GetClientByClientReferenceQuery(string ClientReference)
        {
            this.ClientReference = ClientReference;
        }
    }
}
