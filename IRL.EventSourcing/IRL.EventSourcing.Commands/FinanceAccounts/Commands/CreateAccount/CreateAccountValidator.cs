using FluentValidation;

namespace IRL.EventSourcing.Application.FinanceAccounts.Commands.CreateAccount
{
    public class CreateAccountValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountValidator()
        {
            RuleFor(a => a.CustomerCode)
                .MaximumLength(100)
                .NotEmpty();
        }
    }
}