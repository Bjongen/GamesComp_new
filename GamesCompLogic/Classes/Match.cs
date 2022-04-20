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
        public int FinalScore;
        public Team Team;
        public DateTime MatchTime;

        public Match(Team team, DateTime matchtime)
        {
            Team = team;
            MatchTime = matchtime;
        }

        public Match(int finalscore, Team team, DateTime matchtime)
        {
            FinalScore = finalscore;
            Team = team;
            MatchTime = matchtime;
        }

        public Match(MatchDto matchDto)
        {
            FinalScore = matchDto.FinalScore;
            Team = new Team(matchDto.teamdto);
            MatchTime = matchDto.Matchtime;
        }

        public MatchDto ToDto()
        {
            TeamDto teamDto = new();
            Team.ToDto();
            return new MatchDto
            {
                FinalScore = FinalScore,
                teamdto = teamDto,
                Matchtime = MatchTime
            };
        }

        public void SetFinalScore(int finalscore)
        {
            FinalScore = finalscore;
        }
    }
}
