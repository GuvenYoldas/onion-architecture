using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUVENYOLDAS.Core.DBName.Interfaces.Base
{
    public interface IBaseAuditable
    {
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}
