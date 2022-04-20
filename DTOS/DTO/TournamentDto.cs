using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCompInterface.Dtos
{
    public struct TournamentDto
    {
        public int TournamentId;
        public string Winner;
        public string Game;
        public string Region;

        public List<TeamDto> teamDtos;
        public List<DEBDto> debDtos;
        public List<PouleDto> pouleDtos;
    }
}
