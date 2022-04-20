using GamesCompInterface.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCompInterface
{
    public struct TeamDto
    {
        public int TeamId;
        public string TeamName;
        public int SkillRating;
        public int Wins;

        public List<AccountDto> AccountDtos;
    }
}
