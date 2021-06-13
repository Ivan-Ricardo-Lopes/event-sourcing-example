using FluentValidation;

namespace IRL.EventSourcing.Commands.FinanceAccounts.CreateAccount
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