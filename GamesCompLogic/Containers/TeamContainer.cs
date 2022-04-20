using GamesCompLogic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCompLogic.Containers
{
    public class TeamContainer
    {
        public List<Team> _teams = new();
        public IReadOnlyCollection<Team> GetTeams()
        {
            return _teams;
        }
        public void CreateTeam(Team team)
        {
            if (_teams.Contains(team))
            {
                throw new ArgumentException("Team already exists");
            }
            _teams.Add(team);
        }

        public void DeleteTeam(Team team)
        {
            if (!_teams.Contains(team))
            {
                throw new ArgumentException("Can not delete non-existing team");
            }

            _teams.Remove(team);
        }
    }
}
