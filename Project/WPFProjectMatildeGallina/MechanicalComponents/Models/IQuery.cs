using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalComponents.Models
{
    interface IQuery
    {
        void InsertContainer(string s);
        void AlterProperties(string s);
        void SelectContainers(string s);
    }
}
