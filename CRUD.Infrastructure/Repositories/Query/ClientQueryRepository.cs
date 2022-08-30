using Dapper;
using CRUD.Core.Entities;
using CRUD.Core.Repositories.Query;
using CRUD.Infrastructure.Repositories.Query.Base;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CRUD.Infrastructure.Repositories.Query
{
    // QueryRepository class for Client
    internal class ClientQueryRepository : QueryRepository<Client>, IClientQueryRepository
    {
        public ClientQueryRepository(IConfiguration configuration)
             : base(configuration)
        {

        }

        public async Task<IReadOnlyList<Client>> GetAllAsync()
        {
            try
            {
                var query = @"SELECT  ClinetId, ClientName, ClientShortName, Address, Contact, Email, ContactPerson, Bin_No, Tin_No, IRC_No, ClientReference, 
                              GRSLicenceNumber, Remarks, ClientType, LedgerApproveStatus, ClientApproveStatus, GRSHOAddress, GRSFOAddress
                              FROM tblClientInformation";

                using var connection = CreateConnection();
                return (await connection.QueryAsync<Client>(query)).ToList();
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<Client> GetByIdAsync(string id)
        {
            try
            {
                var query = @"SELECT ClinetId, ClientName, ClientShortName, Address, Contact, Email, ContactPerson, Bin_No, Tin_No, IRC_No, ClientReference, 
                              GRSLicenceNumber, Remarks, ClientType, LedgerApproveStatus, ClientApproveStatus, GRSHOAddress, GRSFOAddress
                              FROM tblClientInformation WHERE ClinetId = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("ClinetId", id, DbType.String);

                return await DataFetchWithDBConnection(query, parameters);
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        public async Task<Client> GetClientByBinNumber(string binNumber)
        {
            var query = @"SELECT ClinetId, ClientName, Address,  Bin_No,  ClientReference, ClientType
                              FROM tblClientInformation WHERE Bin_No = @binNumber";

            var parameters = new DynamicParameters();
            parameters.Add("Bin_No", binNumber, DbType.String);

            return await DataFetchWithDBConnection(query, parameters);
        }

        public async Task<Client> GetClientByClientApproveStatus(bool clientApproveStatus)
        {
            var query = @"SELECT ClinetId, ClientName, Address,  Bin_No,  ClientReference, ClientType, ClientApproveStatus
                              FROM tblClientInformation WHERE ClientApproveStatus = @clientApproveStatus";

            var parameters = new DynamicParameters();
            parameters.Add("ClientApproveStatus", clientApproveStatus, DbType.Boolean);

            return await DataFetchWithDBConnection(query, parameters);
        }            

        public async Task<Client> GetClientByLedgerApproveStatus(bool ledgerApproveStatus)
        {
            var query = @"SELECT ClinetId, ClientName, Address,  Bin_No,  ClientReference, ClientType, LedgerApproveStatus
                              FROM tblClientInformation WHERE LedgerApproveStatus = @clientApproveStatus";

            var parameters = new DynamicParameters();
            parameters.Add("LedgerApproveStatus", ledgerApproveStatus, DbType.Boolean);

            return await DataFetchWithDBConnection(query, parameters);
        }

        public async Task<Client> GetClientByLedgerUnapproveStatus(bool ledgerUnapproveStatus)
        {
            var query = @"SELECT ClinetId, ClientName, Address,  Bin_No,  ClientReference, ClientType, LedgerApproveStatus
                              FROM tblClientInformation WHERE LedgerApproveStatus = @clientApproveStatus";

            var parameters = new DynamicParameters();
            parameters.Add("LedgerApproveStatus", ledgerUnapproveStatus, DbType.Boolean);

            return await DataFetchWithDBConnection(query, parameters);
        }

        public async Task<Client> GetClientByClientReference(string clientReference)
        {
            var query = @"SELECT ClinetId, ClientName, Address,  Bin_No,  ClientReference, ClientType, LedgerApproveStatus
                          FROM tblClientInformation WHERE ClientReference = @clientReference";

            var parameters = new DynamicParameters();
            parameters.Add("ClientReference", clientReference, DbType.String);

            return await DataFetchWithDBConnection(query, parameters);
        }

        public async Task<Client> GetClientByClientType(string clientType)
        {
            var query = @"SELECT ClinetId, ClientName, Address,  Bin_No,  ClientReference, ClientType, LedgerApproveStatus
                          FROM tblClientInformation WHERE ClientType = @clientType";

            var parameters = new DynamicParameters();
            parameters.Add("ClientType", clientType, DbType.String);

            return await DataFetchWithDBConnection(query, parameters);
        }

        private async Task<Client> DataFetchWithDBConnection(string query, DynamicParameters parameters)
        {
            using (var connection = CreateConnection())
            {
                return (await connection.QueryFirstOrDefaultAsync<Client>(query, parameters));
            }
        }
    }
}
