using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.FantasyLeagues
{
    public class InsertLeagueAdmin
    {
        public class Command : IRequest<Result<Unit>>
        {
            public FantasyLeagueTeamDto FantasyLeagueTeam { get; set; }
        }
    }
}