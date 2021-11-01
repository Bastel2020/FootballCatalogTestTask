using Football.Database;
using Football.Interfaces;
using Football.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Repositories
{
    public class DefaultTeamsRepository : ITeamsRepository
    {
        private readonly DefaultDbContext _db;
        public DefaultTeamsRepository(DefaultDbContext db)
        {
            _db = db;
        }

        public async Task<TeamRecord> ContainsTeam(string teamName)
        {
            return await _db.Teams.FirstOrDefaultAsync(t => t.Name.ToLower() == teamName.ToLower());
        }

        public async Task<TeamRecord> CreateTeam(string teamName)
        {
            if (await ContainsTeam(teamName) != null)
                return null;
            
            var footballerTeam = new TeamRecord(teamName);
            await _db.Teams.AddAsync(footballerTeam);
            await _db.SaveChangesAsync();
            return footballerTeam;
        }

        public async Task<bool> CreateTeam(TeamRecord teamToAdd)
        {
            if ((await _db.Teams.FirstOrDefaultAsync(t => t.Name == teamToAdd.Name)) != null ||
                (await _db.Teams.FirstOrDefaultAsync(t => t.Id == teamToAdd.Id)) != null)
                return false;

            else
            {
                await _db.AddAsync(teamToAdd);
                return true;
            }
        }

        public async Task<List<TeamRecord>> GetTeams()
        {
            return await _db.Teams.ToListAsync();
        }

        public async Task<List<string>> GetTeamsNames()
        {
            return await _db.Teams
                .Select(t => t.Name)
                .ToListAsync();
        }
    }
}
