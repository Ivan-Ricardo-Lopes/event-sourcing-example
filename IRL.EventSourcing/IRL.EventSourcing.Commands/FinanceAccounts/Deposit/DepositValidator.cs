using FluentValidation;

namespace IRL.EventSourcing.Commands.FinanceAccounts.Deposit
{
    public class DepositValidator : AbstractValidator<DepositCommand>
    {
        public DepositValidator()
        {
            RuleFor(a => a.Amount)
                .GreaterThan(0)
                .WithMessage("Amount must be greater than 0.");

            RuleFor(a => a.CustomerCode)
                .NotEmpty();

            RuleFor(a => a.Description)
                .MaximumLength(100)
                .NotEmpty();
        }
    }
}