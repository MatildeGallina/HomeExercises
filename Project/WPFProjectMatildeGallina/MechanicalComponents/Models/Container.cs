using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalComponents.Models
{
    abstract class Container : IQuery, IVisibility
    {
        public abstract void InsertContainer(string s);
        public abstract void SelectContainers(string s);
        public abstract void AlterProperties(string s);

        void IVisibility.VisibilityChanged()
        {
            throw new NotImplementedException();
        }
    }
}
