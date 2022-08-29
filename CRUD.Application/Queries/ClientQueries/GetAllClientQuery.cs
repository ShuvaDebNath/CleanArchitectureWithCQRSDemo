using MediatR;
using CRUD.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.Queries.ClientQueries
{
    // Client query with List<Client> response
    public class GetAllClientQuery : IRequest<List<Client>>
    {
    }
}
