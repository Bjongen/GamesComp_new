using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCompInterface.Dtos
{
    public struct PouleDto
    {
        public string Name;
        public int Score;
        public int Advantage;

        public List<MatchDto> MatchDtos;
    }
}
