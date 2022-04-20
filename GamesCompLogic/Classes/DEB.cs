using GamesCompInterface.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCompLogic.Classes
{
    public class DEB
    {
        public string Name;

        public Match match;

        public DEB(string name, Match match)
        {
            Name = name;
            this.match = match;
        }

        public DEB(DEBDto dEBDto)
        {
            Name = dEBDto.Name;
            match = new Match(dEBDto.matchDto);
        }
        public DEBDto ToDto()
        {
            MatchDto matchDto = new();
            match.ToDto();
            return new DEBDto
            {
                Name = Name,
                matchDto = matchDto
            };
        }
    }
}
