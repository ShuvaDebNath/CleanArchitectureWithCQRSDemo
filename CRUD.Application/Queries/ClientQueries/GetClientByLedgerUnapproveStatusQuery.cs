using CRUD.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.Queries.ClientQueries
{
    public class GetClientByLedgerUnapproveStatusQuery : IRequest<Client>
    {
        public bool LedgerApproveStatus { get; private set; }

        public GetClientByLedgerUnapproveStatusQuery(bool LedgerApproveStatus)
        {
            this.LedgerApproveStatus = LedgerApproveStatus;
        }
    }
}
