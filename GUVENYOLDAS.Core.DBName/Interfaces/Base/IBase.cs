using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUVENYOLDAS.Core.DBName.Interfaces.Base
{
    public interface IBase
    {

    }
    public interface IBase<TKey>
    {
        TKey ID { get; set; }
    }
}
