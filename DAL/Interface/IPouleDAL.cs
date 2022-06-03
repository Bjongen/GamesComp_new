using GamesCompInterface.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCompDAL.Interface
{
    public interface IPouleDAL
    {
        public PouleDto[] GetALL();
        public int CreatePoule(PouleDto pouleDto);
        public int DeletePoule(PouleDto pouleDto);
        public int UpdatePoule(PouleDto pouleDto);
    }
}
