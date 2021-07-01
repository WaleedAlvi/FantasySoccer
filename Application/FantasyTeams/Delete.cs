using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using MediatR;
using Persistence;

namespace Application.FantasyTeams
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid FantasyTeamID { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var fantasyTeam = await _context.FantasyTeams.FindAsync(request.FantasyTeamID);
                if (fantasyTeam == null) return null;
                _context.Remove(fantasyTeam);
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to delete fantasy team");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}