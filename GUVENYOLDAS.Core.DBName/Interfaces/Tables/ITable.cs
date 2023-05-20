using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUVENYOLDAS.Core.DBName.Interfaces.Tables
{
    public interface ITable
    {
        string FullName { get; set;  }
        int Age { get; set;  }
    }
}
