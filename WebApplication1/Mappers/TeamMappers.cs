using WebApplication1.Dtos.Team;
using WebApplication1.Models;

namespace WebApplication1.Mappers
{
    public static class TeamMappers
    {
        public static TeamDto ToTeamDto(this Team teamModel)
        {
            return new TeamDto
            {
                ID = teamModel.ID,
                Name = teamModel.Name,
                Country = teamModel.Country
            };
        }

        public static Team ToTeamFromCreateTeamDto(this CreateTeamDto teamModel)
        {
            return new Team
            {
                Name = teamModel.Name,
                Country = teamModel.Country
            };
        }
    }
}
