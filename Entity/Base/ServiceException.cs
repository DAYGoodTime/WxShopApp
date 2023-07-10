using Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Base
{
    public class ServiceException : Exception
    {
        public ServiceErrorCode ErrorCode { get; }

        public ServiceException(ServiceErrorCode errorCode,string message) :base(message) { 
            ErrorCode = errorCode;
        }
        public ServiceException(ServiceErrorCode errorCode, string message, Exception innerException) : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
