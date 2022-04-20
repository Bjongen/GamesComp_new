using GamesCompLogic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCompLogic.Containers
{
    public class TournamentContainer
    {
        public List<Tournament> _tournaments = new();

        public IReadOnlyCollection<Tournament> GetTournaments()
        {
            return _tournaments;
        }

        public void CreateTournament(Tournament tournament)
        {
            if (_tournaments.Contains(tournament))
            {
                throw new ArgumentException("Tournament already exists");
            }

            _tournaments.Add(tournament);
        }

        public void RemoveTournament(Tournament tournament)
        {
            if (!_tournaments.Contains(tournament))
            {
                throw new ArgumentException("Can not remove non existing tournament");
            }

            _tournaments.Remove(tournament);
        }
    }
}
