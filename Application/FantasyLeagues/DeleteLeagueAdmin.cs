using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.FantasyLeagues
{
    public class DeleteLeagueAdmin
    {
        public class Command : IRequest<Result<Unit>>
        {
            public FantasyLeagueAdminDto FantasyLeagueAdmin { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.FantasyLeagueAdmin).SetValidator(new FantasyLeagueInsertAdminValidator());
            }
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
                var fantasyLeagueAdmin = _context.FantasyLeaguesAdmins
                                .Where(flt => flt.FantasyLeagueID == request.FantasyLeagueAdmin.FantasyLeagueID)
                                .Where(flt => flt.PersonID == request.FantasyLeagueAdmin.PersonID)
                                .FirstOrDefault();
                if (fantasyLeagueAdmin == null) return null;
                _context.Remove(fantasyLeagueAdmin);

                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to remove admin from league");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}