using IRL.EventSourcing.Application.Common;
using IRL.EventSourcing.Domain.FinanceAccounts.DomainEvents;
using IRL.EventSourcing.Domain.FinanceAccounts.Entities;
using IRL.EventSourcing.Domain.FinanceAccounts.ValueObjects;
using IRL.EventSourcing.Infra.MongoDb.EventStore;
using IRL.EventSourcing.Infra.Stream;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IRL.EventSourcing.Application.FinanceAccounts.Commands.Deposit
{
    public class DepositHandler : IRequestHandler<DepositCommand, CommandResponse<DepositResponse>>
    {
        private readonly DepositValidator _validator;
        private readonly IEventStore _eventStore;
        private readonly IEventStream _stream;

        public DepositHandler(DepositValidator validator, IEventStore eventStore, IEventStream stream)
        {
            this._validator = validator;
            this._eventStore = eventStore;
            this._stream = stream;
        }

        public async Task<CommandResponse<DepositResponse>> Handle(DepositCommand request, CancellationToken token)
        {
            var response = new CommandResponse<DepositResponse>();

            response.AddError(_validator.Validate(request).Errors.Select(x => x.ErrorMessage));

            if (!response.IsValid)
                return response;

            var aggregateEvents = await _eventStore.LoadAsync(new FinanceAccountId(request.AccountCode));

            var financeAccount = new FinanceAccount(aggregateEvents);

            financeAccount.Deposit(request.Amount, request.Description, out MoneyDeposited @event);

            await _stream.Publish(nameof(FinanceAccount), @event, request.AccountCode.ToString());
            return response;
        }
    }
}