using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Base
{
    public class Bool
    {
        public bool isSuccess { get; set; } = true;

        public string reason { get; set; }

        public Bool() { }

        public Bool(bool isSuccess, string reason)
        {
            this.isSuccess = isSuccess;
            this.reason = reason;
        }
    }
}
