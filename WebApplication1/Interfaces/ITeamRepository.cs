﻿using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface ITeamRepository
    {
        Task<List<Team>> GetAllAsync();
    }
}
