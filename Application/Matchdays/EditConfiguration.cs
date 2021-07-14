using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Matchdays
{
    public class EditConfiguration
    {
        public class Command : IRequest<Result<Unit>>
        {
            public MatchdayTeamConfiguration matchdayTeamConfig { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.matchdayTeamConfig).SetValidator(new MatchdayTeamConfigValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var matchdayTeamConfig = await _context.MatchdayTeamConfigurations
                                            .FindAsync(request.matchdayTeamConfig.MatchdayTeamConfigurationID);
                if (matchdayTeamConfig == null) return null;
                _mapper.Map(request.matchdayTeamConfig, matchdayTeamConfig);

                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to update matchday team configuration");
                return Result<Unit>.Success(Unit.Value);
            }
        }

    }
}