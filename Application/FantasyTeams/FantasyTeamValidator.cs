using Domain;
using FluentValidation;

namespace Application.FantasyTeams
{
    public class FantasyTeamValidator : AbstractValidator<FantasyTeam>
    {
        public FantasyTeamValidator()
        {
            RuleFor(x => x.PersonID).NotEmpty();
            RuleFor(x => x.FantasyTeamName).NotEmpty();
            RuleFor(x => x.MoneyBalance)
                .LessThanOrEqualTo(100)
                .GreaterThan(0)
                .NotEmpty();
            RuleFor(x => x.GoalieOneID).NotEmpty();
            RuleFor(x => x.GoalieTwoID).NotEmpty();
            RuleFor(x => x.DefenderOneID).NotEmpty();
            RuleFor(x => x.DefenderTwoID).NotEmpty();
            RuleFor(x => x.DefenderThreeID).NotEmpty();
            RuleFor(x => x.DefenderFourID).NotEmpty();
            RuleFor(x => x.DefenderFiveID).NotEmpty();
            RuleFor(x => x.MidfielderOneID).NotEmpty();
            RuleFor(x => x.MidfielderTwoID).NotEmpty();
            RuleFor(x => x.MidfielderThreeID).NotEmpty();
            RuleFor(x => x.MidfielderFourID).NotEmpty();
            RuleFor(x => x.MidfielderFiveID).NotEmpty();
            RuleFor(x => x.ForwardOneID).NotEmpty();
            RuleFor(x => x.ForwardTwoID).NotEmpty();
            RuleFor(x => x.ForwardThreeID).NotEmpty();
        }
    }
}
