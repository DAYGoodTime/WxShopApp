using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Enum
{
    public enum ServiceErrorCode
    {
        NormalError = 0,
        ArgumentNull = 404,
        ArgumentError = 403,
        DbContextError = 500,
        UnExpectedError = 600,
    }
}
