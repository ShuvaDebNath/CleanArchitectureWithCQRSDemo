using CRUD.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.Queries.ClientQueries
{
    public class GetClientByClientApproveStatusQuery : IRequest<Client>
    {
        public bool ClientApproveStatus { get; private set; }

        public GetClientByClientApproveStatusQuery(bool ClientApproveStatus)
        {
            this.ClientApproveStatus = ClientApproveStatus;
        }
    }
}
