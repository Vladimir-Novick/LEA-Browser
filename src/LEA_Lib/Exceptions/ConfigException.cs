using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEA_Lib.Exceptions
{
    public class ConfigException : AccessViolationException
    {
        public ConfigException(String message) : base(message) { }
    }
}
