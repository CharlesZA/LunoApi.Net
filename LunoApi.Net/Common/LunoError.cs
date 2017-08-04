using System;
using System.Collections.Generic;
using System.Text;

namespace LunoApi.Net.Common
{    
    class LunoError
    {
        public string error { get; set; }
    }

    public class LunoException : Exception
    {
        public LunoException()
            : base() { }

        public LunoException(string message)
            : base(message) { }

        public LunoException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public LunoException(string message, Exception innerException)
            : base(message, innerException) { }

        public LunoException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }
}
