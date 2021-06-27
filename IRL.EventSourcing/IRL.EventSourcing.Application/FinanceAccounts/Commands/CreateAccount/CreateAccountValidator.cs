using FluentValidation;
using IRL.EventSourcing.Infra.Repositories;

namespace IRL.EventSourcing.Application.FinanceAccounts.Commands.CreateAccount
{
    public class CreateAccountValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountValidator(IFinanceAccountRepository financeAccountRepository)
        {
            RuleFor(a => a.CustomerCode)
                .MaximumLength(100)
                .NotEmpty();

            RuleFor(a => a.CustomerCode)
                .Custom(async (customerCode, context) =>
                {
                    if (await financeAccountRepository.Exists(customerCode))
                    {
                        context.AddFailure("This customer already has an account.");
                    }
                });
        }
    }
}