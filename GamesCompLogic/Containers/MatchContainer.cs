using GamesCompLogic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCompLogic.Containers
{
    public class MatchContainer
    {
        public List<Match> _matches = new();

        public IReadOnlyCollection<Match> GetMatches()
        {
            return _matches;
        }

        public void CreateMatch(Match match)
        {
            if (_matches.Contains(match))
            {
                throw new ArgumentException("Can not add duplicate match");
            }

            _matches.Add(match);
        }

        public void RemoveMatch(Match match)
        {
            if (!_matches.Contains(match))
            {
                throw new ArgumentException("Can not remove non-existing match");
            }

            _matches.Remove(match);
        }
    }
}
