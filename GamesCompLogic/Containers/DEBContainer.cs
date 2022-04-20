using GamesCompLogic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCompLogic.Containers
{
    public class DEBContainer
    {
        public List<DEB> _debs = new();

        public IReadOnlyCollection<DEB> GetDEBs()
        {
            return _debs;
        }

        public void CreateDEB(DEB deb)
        {
            if (_debs.Contains(deb))
            {
                throw new ArgumentException("DEB already exists");
            }

            _debs.Add(deb);
        }

        public void RemoveDEB(DEB deb)
        {
            if (!_debs.Contains(deb))
            {
                throw new ArgumentException("Can not remove non-existing DEB");
            }

            _debs.Remove(deb);
        }
    }
}
