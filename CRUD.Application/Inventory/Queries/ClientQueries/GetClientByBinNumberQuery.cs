using CRUD.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.Queries.ClientQueries
{
    public class GetClientByBinNumberQuery : IRequest<Client>
    {
        public string Bin_No { get; private set; }

        public GetClientByBinNumberQuery(string Bin_No)
        {
            this.Bin_No = Bin_No;
        }
    }
}
