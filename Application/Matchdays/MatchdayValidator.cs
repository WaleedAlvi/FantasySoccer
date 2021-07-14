using Domain;
using FluentValidation;

namespace Application.Matchdays
{
    public class MatchdayTeamConfigValidator : AbstractValidator<Domain.MatchdayTeamConfiguration>
    {
        public MatchdayTeamConfigValidator()
        {
            RuleFor(x => x.MatchdayTeamConfigurationID).NotEmpty();
            RuleFor(x => x.FantasyTeamID).NotEmpty();
            RuleFor(x => x.MatchdayID).NotEmpty();
            RuleFor(x => x.FormationID).NotEmpty();
            RuleFor(x => x.CaptainID).NotEmpty();
            RuleFor(x => x.DateUpdated).NotEmpty();
        }
    }

    public class MatchdayTeamConfigDtoValidator : AbstractValidator<MatchdayTeamConfigDto>
    {
        public MatchdayTeamConfigDtoValidator()
        {
            RuleFor(x => x.FantasyTeamID).NotEmpty();
            RuleFor(x => x.MatchdayID).NotEmpty();
            RuleFor(x => x.FormationID).NotEmpty();
            RuleFor(x => x.CaptainID).NotEmpty();
        }
    }

    public class MatchdayTeamDtoValidator : AbstractValidator<MatchdayTeamDto>
    {
        public MatchdayTeamDtoValidator()
        {
            RuleFor(x => x.MatchdayTeamConfigurationID).NotEmpty();
            RuleFor(x => x.GoalieID).NotEmpty();
            RuleFor(x => x.PlayerOneID).NotEmpty();
            RuleFor(x => x.PlayerTwoID).NotEmpty();
            RuleFor(x => x.PlayerThreeID).NotEmpty();
            RuleFor(x => x.PlayerFourID).NotEmpty();
            RuleFor(x => x.PlayerFiveID).NotEmpty();
            RuleFor(x => x.PlayerSixID).NotEmpty();
            RuleFor(x => x.PlayerSevenID).NotEmpty();
            RuleFor(x => x.PlayerEightID).NotEmpty();
            RuleFor(x => x.PlayerNineID).NotEmpty();
            RuleFor(x => x.PlayerTenID).NotEmpty();
            RuleFor(x => x.BenchOneID).NotEmpty();
            RuleFor(x => x.BenchTwoID).NotEmpty();
            RuleFor(x => x.BenchThreeID).NotEmpty();
            RuleFor(x => x.BenchFourID).NotEmpty();
        }
    }

    public class MatchdayTeamValidator : AbstractValidator<MatchdayTeam>
    {
        public MatchdayTeamValidator()
        {
            RuleFor(x => x.MatchdayTeamConfigurationID).NotEmpty();
            RuleFor(x => x.GoalieID).NotEmpty();
            RuleFor(x => x.PlayerOneID).NotEmpty();
            RuleFor(x => x.PlayerTwoID).NotEmpty();
            RuleFor(x => x.PlayerThreeID).NotEmpty();
            RuleFor(x => x.PlayerFourID).NotEmpty();
            RuleFor(x => x.PlayerFiveID).NotEmpty();
            RuleFor(x => x.PlayerSixID).NotEmpty();
            RuleFor(x => x.PlayerSevenID).NotEmpty();
            RuleFor(x => x.PlayerEightID).NotEmpty();
            RuleFor(x => x.PlayerNineID).NotEmpty();
            RuleFor(x => x.PlayerTenID).NotEmpty();
            RuleFor(x => x.BenchOneID).NotEmpty();
            RuleFor(x => x.BenchTwoID).NotEmpty();
            RuleFor(x => x.BenchThreeID).NotEmpty();
            RuleFor(x => x.BenchFourID).NotEmpty();
        }
    }
}