using GamesCompDAL.IDAL;
using GamesCompInterface.Dtos;
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
        public List<Tournament> _tournaments;
        private ITournamentDAL iTournamentDAL;

        public TournamentContainer(ITournamentDAL iTournamentDAL)
        {
            this.iTournamentDAL = iTournamentDAL;
            _tournaments = new List<Tournament>();

        }
        public IReadOnlyCollection<Tournament> GetTournaments()
        {
            return _tournaments;
        }

        public int CreateTournament(Tournament tournament)
        {
            TournamentDto tournamentDto = new TournamentDto()
            {
                Winner = tournament.Winner,
                Game = tournament.Game,
                Region = tournament.Region
            };
            _tournaments.Add(new Tournament(tournamentDto));
            return iTournamentDAL.CreateTournament(tournamentDto);
        }

        public int RemoveTournament(Tournament tournament)
        {
            TournamentDto tournamentDto = new TournamentDto()
            {
                Winner = tournament.Winner,
                Game = tournament.Game,
                Region = tournament.Region
            };
            return iTournamentDAL.DeleteTournament(tournamentDto);
        }

        public Tournament GetInfo(int id)
        {
            var dto = iTournamentDAL.GetInfo(id);
            Tournament tournament = new(dto);
            return tournament;
        }
        public IList<Tournament> GetAll()
        {
            var tournamentDtos = iTournamentDAL.GetALL();
            List<Tournament> tournaments = new();
            foreach (var dto in tournamentDtos)
            {
                tournaments.Add(new Tournament(dto));
            }

            return _tournaments = tournaments;
        }
    }
}
