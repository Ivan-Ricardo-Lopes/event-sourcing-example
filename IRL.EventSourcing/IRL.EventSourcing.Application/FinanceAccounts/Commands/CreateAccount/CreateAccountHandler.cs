using IRL.EventSourcing.Application.Common;
using IRL.EventSourcing.Domain.FinanceAccounts.DomainEvents;
using IRL.EventSourcing.Domain.FinanceAccounts.Entities;
using IRL.EventSourcing.Infra.Repositories;
using IRL.EventSourcing.Infra.Stream;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IRL.EventSourcing.Application.FinanceAccounts.Commands.CreateAccount
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, CommandResponse<CreateAccountResponse>>
    {
        private readonly CreateAccountValidator _validator;
        private readonly IEventStream stream;
        private readonly IFinanceAccountCodeRepository _accountCodeRepository;

        public CreateAccountHandler(CreateAccountValidator validator,
            IEventStream stream,
            IFinanceAccountCodeRepository accountCodeRepository)
        {
            this._validator = validator;
            this.stream = stream;
            this._accountCodeRepository = accountCodeRepository;
        }

        public async Task<CommandResponse<CreateAccountResponse>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse<CreateAccountResponse>();

            response.AddError(_validator.Validate(request).Errors.Select(x => x.ErrorMessage));

            if (!response.IsValid)
                return response;

            var accountCode = await _accountCodeRepository.GetLastAccountCode() ?? 10000;

            var account = FinanceAccount.Create(accountCode, request.CustomerCode, out FinanceAccountCreated @event);

            await stream.Publish(nameof(FinanceAccount), @event, account.CustomerCode);

            return response;
        }
    }
}