using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDBContext _context;
        public TeamRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        Task<List<Team>> ITeamRepository.GetAllAsync()
        {
            return  _context.Teams.ToListAsync();
        }
    }
}
