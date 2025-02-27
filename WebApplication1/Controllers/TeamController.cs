using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dtos.Team;
using WebApplication1.Interfaces;
using WebApplication1.Mappers;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("WebApplication1/teams")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ITeamRepository _teamRepo;
        public TeamController(ApplicationDBContext context, ITeamRepository teamRepo)
        {
            _context = context;
            _teamRepo = teamRepo;
        }

        [HttpGet]
        public async Task<IActionResult>  GetAll()
        {
            var teams = await _teamRepo.GetAllAsync();

            var results = teams.Select(t => t.ToTeamDto());

            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var team = await _context.Teams.FindAsync(id);

            if(team == null)
            {
                return NotFound();
            }

            return Ok(team.ToTeamDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]  CreateTeamDto teamDto)
        {
            var team = teamDto.ToTeamFromCreateTeamDto();
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = team.ID }, team.ToTeamDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTeamDto updateDto)
        {
            var teamModel = await _context.Teams.FirstOrDefaultAsync(x => x.ID == id);

            if(teamModel == null)
            {
                return NotFound();
            }

            teamModel.Name = updateDto.Name;
            teamModel.Country = updateDto.Country;

            await _context.SaveChangesAsync();

            return Ok(teamModel.ToTeamDto());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var teamToDelete = _context.Teams.FirstOrDefault(x => x.ID == id);

            if(teamToDelete == null)
            {
                return NotFound();
            }

            _context.Remove(teamToDelete);
            _context.SaveChanges();

            return Ok();
           
        }
    }
}
