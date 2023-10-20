using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicSun.Core.Exceptions
{
    public class NotParseableException : Exception
    {
        public NotParseableException() : base("File can not be parsed") { }
    }
}
