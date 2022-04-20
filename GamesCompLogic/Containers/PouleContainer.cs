using GamesCompLogic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCompLogic.Containers
{
    public class PouleContainer
    {
        public List<Poule> _poules = new();

        public IReadOnlyCollection<Poule> GetPoules()
        {
            return _poules;
        }

        public void CreatePoule(Poule poule)
        {
            if (_poules.Contains(poule))
            {
                throw new ArgumentException("Can not add duplicate poule");
            }

            _poules.Add(poule);
        }

        public void RemovePoule(Poule poule)
        {
            if (!_poules.Contains(poule))
            {
                throw new ArgumentException("Can not remove non-existing poule");
            }

            _poules.Remove(poule);
        }
    }
}
