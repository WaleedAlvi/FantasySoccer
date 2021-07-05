using Application.Countries;
using Application.FantasyTeams;
using Application.Leagues;
using Application.Persons;
using Application.Players;
using Application.FantasyLeagues;
using Application.Teams;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Person, Person>();
            CreateMap<Person, PersonDto>().ForMember(d => d.FavouriteTeam, o => o.MapFrom(s => s.Team));
            CreateMap<Country, CountryDto>();
            CreateMap<Team, TeamDto>();
            CreateMap<League, LeagueDto>();
            CreateMap<User, UserDto>();
            CreateMap<Player, PlayerDto>();
            CreateMap<FantasyTeam, FantasyTeam>();
            CreateMap<FantasyTeam, FantasyTeamDto>();
            CreateMap<FantasyLeague, FantasyLeague>();
            CreateMap<FantasyLeague, FantasyLeagueDto>();
            CreateMap<FantasyLeagueAdmin, FantasyLeagueAdminsDto>();
            CreateMap<FantasyLeagueTeams, FantasyLeagueTeamDto>();
        }
    }
}