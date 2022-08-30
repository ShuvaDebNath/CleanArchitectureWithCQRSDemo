using CRUD.Core.Common;
using CRUD.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.Response
{
    // Client response or DTO class
    public class ClientResponse : IMapFrom<Client>
    {
        public string ClinetId { get; set; } = Guid.NewGuid().ToString();
        public string? ClientName { get; set; }
        public string? ClientShortName { get; set; }
        public string? Address { get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }
        public string? ContactPerson { get; set; }
        public string? Bin_No { get; set; }
        public string? Tin_No { get; set; }
        public string? IRC_No { get; set; }
        public string? ClientReference { get; set; }
        public string? GRSLicenceNumber { get; set; }
        public string? Remarks { get; set; }
        public string? ClientType { get; set; }
        public Nullable<bool> LedgerApproveStatus { get; set; } = true;
        public Nullable<bool> ClientApproveStatus { get; set; } = true;
        public string? GRSHOAddress { get; set; }
        public string? GRSFOAddress { get; set; }
    }
}
