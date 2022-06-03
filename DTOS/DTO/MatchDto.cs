using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCompInterface.Dtos
{
    public struct MatchDto
    {
        public int MatchId;
        public int FinalScore;
        public string MatchName;
        public TeamDto teamdto;
        public DateTime MatchDate;
    }
}
