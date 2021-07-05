using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using MediatR;
using Persistence;

namespace Application.FantasyLeagues
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid FantasyLeagueID { get; set; }
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
                var fantasyLeague = await _context.FantasyLeagues.FindAsync(request.FantasyLeagueID);
                if (fantasyLeague == null) return null;
                _context.Remove(fantasyLeague);
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to delete Fantasy League");
                return Result<Unit>.Success(Unit.Value);
            }
        }

    }
}