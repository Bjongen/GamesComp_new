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
        public string Name;
        public int Score;
        public int Advantage;

        List<Match> _matches = new();

        public Poule(string name, List<Match> matches)
        {
            Name = name;
            _matches = matches;
            Score = 0;
            Advantage = 0;
        }

        public Poule(PouleDto pouleDto)
        {
            Name = pouleDto.Name;
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
                Name = Name,
                Score = Score,
                Advantage = Advantage,
                MatchDtos = matchDtos
            };
        }
    }
}
