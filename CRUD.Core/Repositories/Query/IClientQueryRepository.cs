using CRUD.Core.Entities;
using CRUD.Core.Repositories.Query.Base;

namespace CRUD.Core.Repositories.Query
{
    public interface IClientQueryRepository : IQueryRepository<Client>
    {
        //Client operation which is not generic
        Task<IReadOnlyList<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(string id);
        Task<Client> GetClientByBinNumber(string binNumber);
        Task<Client> GetClientByClientType(string clientType);
        Task<Client> GetClientByClientReference(string clientReference);
        Task<Client> GetClientByLedgerApproveStatus(bool ledgerApproveStatus);
        Task<Client> GetClientByLedgerUnapproveStatus(bool ledgerUnapproveStatus);
        Task<Client> GetClientByClientApproveStatus(bool clientApproveStatus);
    }
}
