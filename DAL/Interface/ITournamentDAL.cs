using GamesCompInterface.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCompDAL.IDAL
{
    public interface ITournamentDAL
    {
        public TournamentDto[] GetALL();
        public TournamentDto GetInfo(int id);
        public int CreateTournament(TournamentDto tournamentDto);
        public int DeleteTournament(TournamentDto tournamentDto);
        public int UpdateTournament(TournamentDto tournamentDto);
    }
}
