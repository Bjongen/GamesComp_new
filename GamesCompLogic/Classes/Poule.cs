using GamesCompInterface.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCompLogic.Classes
{
    public class Poule
    {
        public int PouleId;
        public string PouleName;
        public int Score;
        public int Advantage;

        List<Match> _matches = new();

        public Poule(string name, List<Match> matches)
        {
            PouleName = name;
            _matches = matches;
            Score = 0;
            Advantage = 0;
        }

        public Poule(PouleDto pouleDto)
        {
            PouleId = pouleDto.PouleId;
            PouleName = pouleDto.PouleName;
            Score = pouleDto.Score;
            Advantage = pouleDto.Advantage;

            _matches = new List<Match>();
        }

        public void SetScore(int score)
        {
            Score = score;
        }

        public void SetAdvantage(int advantage)
        {
            Advantage = advantage;
        }

        public PouleDto ToDto()
        {
            List<MatchDto> matchDtos = new();
            foreach (var match in _matches)
            {
                matchDtos.Add(match.ToDto());
            }
            return new PouleDto
            {
                PouleName = PouleName,
                Score = Score,
                Advantage = Advantage,
                MatchDtos = matchDtos
            };
        }
    }
}
