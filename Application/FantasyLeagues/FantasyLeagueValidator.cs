using System;
using Domain;
using FluentValidation;

namespace Application.FantasyLeagues
{
    public class FantasyLeagueCreateValidator : AbstractValidator<FantasyLeagueCreateDto>
    {
        public FantasyLeagueCreateValidator()
        {
            RuleFor(x => x.LeagueName).NotEmpty();
            RuleFor(x => x.LeagueCaption).NotEmpty();
            RuleFor(x => x.LeagueLogo).Equals("This is the default league logo");
            RuleFor(x => x.LeagueKey).NotEmpty();
            RuleFor(x => x.NumberOfTeams).NotEmpty().LessThan(21).GreaterThan(4);
            RuleFor(x => x.AdminID).NotEmpty();
        }
    }

    public class FantasyLeagueValidator : AbstractValidator<FantasyLeague>
    {
        public FantasyLeagueValidator()
        {
            RuleFor(x => x.FantasyLeagueID).NotEmpty();
            RuleFor(x => x.LeagueName).NotEmpty();
            RuleFor(x => x.LeagueCaption).NotEmpty();
            RuleFor(x => x.NumberOfTeams).NotEmpty().LessThan(21).GreaterThan(4);
            RuleFor(x => x.DateUpdated).Equals(DateTime.Now);
        }
    }

    public class FantasyLeagueUpdateValidator : AbstractValidator<FantasyLeague>
    {
        public FantasyLeagueUpdateValidator()
        {
            RuleFor(x => x.FantasyLeagueID).NotEmpty();
            RuleFor(x => x.LeagueName).NotEmpty();
            RuleFor(x => x.LeagueCaption).NotEmpty();
            RuleFor(x => x.NumberOfTeams).NotEmpty().LessThan(21).GreaterThan(4);
            RuleFor(x => x.DateUpdated).Equals(DateTime.Now);
        }
    }

    public class FantasyLeagueTeamValidator : AbstractValidator<FantasyLeagueTeamDto>
    {
        public FantasyLeagueTeamValidator()
        {
            RuleFor(x => x.FantasyLeagueID).NotEmpty();
            RuleFor(x => x.FantasyTeamID).NotEmpty();
        }
    }
}