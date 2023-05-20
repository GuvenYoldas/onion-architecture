using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUVENYOLDAS.Core.DBName.Interfaces.Queries
{
    public interface IQuery
    {
        string FullName { get; set; }
        int Age { get; set; }
    }
}
