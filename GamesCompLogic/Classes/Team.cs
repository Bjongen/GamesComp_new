using GamesCompInterface;
using GamesCompInterface.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCompLogic.Classes
{
    public class Team
    {
        public int TeamId;
        public string TeamName;
        public int SkillRating;
        public int Wins;

        public List<Account> _accounts = new();

        public Team(string teamname, List<Account> accounts)
        {
            _accounts = accounts;
            if (_accounts.Count == 0)
            {
                throw new ArgumentOutOfRangeException("Team can not be empty");
            }
            TeamName = teamname;
            SkillRating = 0;
            Wins = 0;
        }

        public Team(TeamDto teamDto)
        {
            TeamId = teamDto.TeamId;
            TeamName = teamDto.TeamName;
            SkillRating = teamDto.SkillRating;
            Wins = teamDto.Wins;
        }

        public void SetWins(int wins)
        {
            Wins = wins;
        }

        public void SetSkillRating(int skillrating)
        {
            SkillRating = skillrating;
        }

        public TeamDto ToDto()
        {
            return new TeamDto
            {
                TeamId = TeamId,
                TeamName = TeamName,
                Wins = Wins,
                SkillRating = SkillRating
            };
        }
    }
}
