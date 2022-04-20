using GamesCompInterface;
using GamesCompInterface.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCompLogic.Classes
{
    public class Tournament
    {
        public int TournamentId;
        public string Winner;
        public string Game;
        public string Region;

        public List<Team> _teams = new();
        public List<Poule> _poules = new();
        public List<DEB> _debs = new();

        public Tournament(int tournamentid, string game, string region, List<Team> teams, List<DEB> debs)
        {
            TournamentId = tournamentid;
            Game = game;
            Region = region;
            _teams = teams;
            _debs = debs;
        }

        public Tournament(TournamentDto tournamentDto)
        {
            TournamentId = tournamentDto.TournamentId;
            Winner = tournamentDto.Winner;
            Game = tournamentDto.Game;
            Region = tournamentDto.Region;

            _teams = new List<Team>();
            _poules = new List<Poule>();
            _debs = new List<DEB>();
        }

        public void SetWinner(string winner)
        {
            Winner = winner;
        }

        public TournamentDto ToDto()
        {
            List<TeamDto> teamDtos = new();
            List<PouleDto> pouleDtos = new();
            List<DEBDto> dEBDtos = new();
            foreach (var team in _teams)
            {
                teamDtos.Add(team.ToDto());
            }
            foreach (var poule in _poules)
            {
                pouleDtos.Add(poule.ToDto());
            }
            foreach (var deb in _debs)
            {
                dEBDtos.Add(deb.ToDto());
            }
            return new TournamentDto
            {
                TournamentId = TournamentId,
                Winner = Winner,
                Game = Game,
                Region = Region,
                teamDtos = teamDtos,
                pouleDtos = pouleDtos,
                debDtos = dEBDtos
            };
        }
    }
}
