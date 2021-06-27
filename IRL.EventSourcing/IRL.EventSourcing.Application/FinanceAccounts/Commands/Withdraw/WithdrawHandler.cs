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

namespace IRL.EventSourcing.Application.FinanceAccounts.Commands.Withdraw
{
    public class WithdrawHandler : IRequestHandler<WithdrawCommand, CommandResponse<WithdrawResponse>>
    {
        private readonly WithdrawValidator _validator;
        private readonly IEventStore _eventStore;
        private readonly IEventStream _stream;

        public WithdrawHandler(WithdrawValidator validator, IEventStore eventStore, IEventStream stream)
        {
            this._validator = validator;
            this._eventStore = eventStore;
            this._stream = stream;
        }

        public async Task<CommandResponse<WithdrawResponse>> Handle(WithdrawCommand request, CancellationToken token)
        {
            var response = new CommandResponse<WithdrawResponse>();

            response.AddError(_validator.Validate(request).Errors.Select(x => x.ErrorMessage));

            if (!response.IsValid)
                return response;

            var aggregateEvents = await _eventStore.LoadAsync(new FinanceAccountId(request.AccountCode));

            var financeAccount = new FinanceAccount(aggregateEvents);

            financeAccount.Withdraw(request.Amount, request.Description, out MoneyWithdrawn @event);

            await _stream.Publish(nameof(FinanceAccount), @event, request.AccountCode.ToString());

            return response;
        }
    }
}