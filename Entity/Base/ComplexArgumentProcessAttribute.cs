using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Base
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ComplexArgumentProcessAttribute : Attribute
    {
        public Type _model { get; set; }

        public ComplexArgumentProcessAttribute(Type model)
        {
            _model = model;
        }

        public Type getMoel()
        {
            return _model;
        }
    }
}
