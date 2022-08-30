using CRUD.Core.Entities;
using CRUD.Core.Repositories.Command;
using CRUD.Infrastructure.Data;
using CRUD.Infrastructure.Repositories.Command.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Infrastructure.Repositories.Command
{
    // Command Repository class for Client
    internal class ClientCommandRepository : CommandRepository<Client>, IClientCommandRepository
    {
        public ClientCommandRepository(ModelContext context) : base(context)
        {

        }
    }
}
