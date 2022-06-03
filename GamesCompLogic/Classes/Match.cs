using GamesCompInterface;
using GamesCompInterface.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCompLogic.Classes
{
    public class Match
    {
        public int MatchId;
        public int FinalScore;
        public int MatchName;
        public Team Team;
        public DateTime MatchDate;

        public Match(Team team, DateTime matchtime)
        {
            Team = team;
            MatchDate = matchtime;
        }

        public Match(int finalscore, Team team, DateTime matchtime)
        {
            FinalScore = finalscore;
            Team = team;
            MatchDate = matchtime;
        }

        public Match(MatchDto matchDto)
        {
            FinalScore = matchDto.FinalScore;
            Team = new Team(matchDto.teamdto);
            MatchDate = matchDto.MatchDate;
        }

        public MatchDto ToDto()
        {
            TeamDto teamDto = new();
            Team.ToDto();
            return new MatchDto
            {
                FinalScore = FinalScore,
                teamdto = teamDto,
                MatchDate = MatchDate
            };
        }

        public void SetFinalScore(int finalscore)
        {
            FinalScore = finalscore;
        }
    }
}
