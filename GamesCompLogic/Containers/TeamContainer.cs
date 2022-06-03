using GamesCompDAL.Interface;
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
        public List<Team> _teams;
        public List<Team> _randomTeams;
        private ITeamDAL iTeamDAL;

        public TeamContainer(ITeamDAL teamDAL)
        {
            iTeamDAL = teamDAL;
            _teams = new List<Team>();
        }
        public IReadOnlyCollection<Team> GetTeams()
        {
            return _teams;
        }

        public IList<Team> GetAll()
        {
            var teamDtos = iTeamDAL.GetAll();
            List<Team> teams = new();
            foreach (var dto in teamDtos)
            {
                teams.Add(new Team(dto));
            }

            return _teams = teams;
        }

        public List<int> RandomizeTeams()
        {
            int[] ids = iTeamDAL.GetId().ToArray();
            List<int> RandomID = new();
            Random r = new Random();
            while(ids.Length != 0)
            {
                int temp = r.Next(ids.Length);
                RandomID.Add(ids[temp]);
                ids = ids.Where(e => e != ids[temp]).ToArray();
            }
            return RandomID;
        }
 
        public Team GetById(int id)
        {
            var dto = iTeamDAL.GetById(id);
            Team team = new(dto);
            return team;
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
