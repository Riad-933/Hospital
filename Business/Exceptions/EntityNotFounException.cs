using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class EntityNotFounException : Exception
    {
        public EntityNotFounException(string? message) : base(message)
        {
        }
    }
}
