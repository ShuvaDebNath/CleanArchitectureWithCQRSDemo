using CRUD.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.Queries.ClientQueries
{
    // Client GetClientByIdQuery with Client response
    public class GetByIdQuery : IRequest<Client>
    {
        public string ClinetId { get; private set; }

        public GetByIdQuery(string ClinetId)
        {
            this.ClinetId = ClinetId;
        }
    }
}
