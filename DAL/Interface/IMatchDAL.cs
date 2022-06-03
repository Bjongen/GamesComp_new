using GamesCompInterface.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCompDAL.Interface
{
    public interface IMatchDAL
    {
        public MatchDto[] GetALL();
        public int CreateMatch(MatchDto matchDto);
        public int DeleteAccount(MatchDto matchDto);
        public int UpdateMatch(MatchDto matchDto);


    }
}
