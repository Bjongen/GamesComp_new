using GamesCompInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCompDAL.Interface
{
    public interface ITeamDAL
    {
        TeamDto[] GetAll();
        int AddTeam(TeamDto teamDto);
        int DeleteTeam(TeamDto teamDto);
        int EditTeam(TeamDto teamDto);
    }
}
