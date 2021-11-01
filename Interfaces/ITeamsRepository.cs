using Football.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Interfaces
{
    public interface ITeamsRepository
    {
        public Task<List<TeamRecord>> GetTeams();
        public Task<List<string>> GetTeamsNames();
        public Task<bool> CreateTeam(TeamRecord teamToAdd);
        public Task<TeamRecord> ContainsTeam(string teamName);
        public Task<TeamRecord> CreateTeam(string teamName);
    }
}
