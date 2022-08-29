using CRUD.Application.Commands.ClientCommands;
using CRUD.Application.Queries.ClientQueries;
using CRUD.Application.Response;
using CRUD.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<Client>> Get()
        {
            return await _mediator.Send(new GetAllClientQuery());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Client> Get(string clinetId)
        {
            return await _mediator.Send(new GetByIdQuery(clinetId));
        }

        [HttpGet("{binNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Client> GetClientByBinNumber(string binNumber)
        {
            return await _mediator.Send(new GetClientByBinNumberQuery(binNumber));
        }

        [HttpGet("{clientType}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Client> GetClientByClientType(string clientType)
        {
            return await _mediator.Send(new GetClientByClientTypeQuery(clientType));
        }

        [HttpGet("{clientReference}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Client> GetClientByClientReference(string clientReference)
        {
            return await _mediator.Send(new GetClientByClientTypeQuery(clientReference));
        }

        [HttpGet("{ledgerApproveStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Client> GetClientByLedgerApproveStatus(bool ledgerApproveStatus)
        {
            return await _mediator.Send(new GetClientByLedgerApproveStatusQuery(ledgerApproveStatus));
        }

        [HttpGet("{ledgerUnapproveStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Client> GetClientByLedgerUnapproveStatus(bool ledgerApproveStatus)
        {
            return await _mediator.Send(new GetClientByLedgerUnapproveStatusQuery(ledgerApproveStatus));
        }

        [HttpGet("{clientApproveStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Client> GetClientByClientApproveStatus(bool clientApproveStatus)
        {
            return await _mediator.Send(new GetClientByClientApproveStatusQuery(clientApproveStatus));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ClientResponse>> CreateClient([FromBody] CreateClientCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPut("EditCustomer/{id}")]
        public async Task<ActionResult> EditClient(string id, [FromBody] EditClientCommand command)
        {
            try
            {
                if (command.ClinetId == id)
                {
                    var result = await _mediator.Send(command);
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

        [HttpDelete("DeleteCustomer/{id}")]
        public async Task<ActionResult> DeleteCustomer(string id)
        {
            try
            {
                string result = string.Empty;
                result = await _mediator.Send(new DeleteClientCommand(id));
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

    }
}
