using IRL.EventSourcing.Application.FinanceAccounts.Commands.CreateAccount;
using IRL.EventSourcing.Application.FinanceAccounts.Commands.Deposit;
using IRL.EventSourcing.Application.FinanceAccounts.Commands.Withdraw;
using IRL.EventSourcing.Application.FinanceAccounts.Queries.AccountStatement;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IRL.EventSourcing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceAccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FinanceAccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("~/finance-accounts/{AccountCode}/statement")]
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] AccountStatementQuery query)
        {
            var result = await _mediator.Send(query);
            if (result.IsSuccess)
                return Ok(result.Payload);

            return BadRequest(result.Errors);
        }

        [Route("~/finance-accounts/")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAccountCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
                return Ok(result.Payload);

            return BadRequest(result.Errors);
        }

        [Route("~/finance-accounts/{accountCode}/deposit")]
        [HttpPost]
        public async Task<IActionResult> Deposit([FromBody] DepositCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
                return Ok(result.Payload);

            return BadRequest(result.Errors);
        }

        [Route("~/finance-accounts/{accountCode}/withdraw")]
        [HttpPost]
        public async Task<IActionResult> Deposit([FromBody] WithdrawCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
                return Ok(result.Payload);

            return BadRequest(result.Errors);
        }
    }
}