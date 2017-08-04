using System;
using System.Collections.Generic;
using System.Text;

namespace LunoApi.Net.Common
{
    public class LunoConfig : IConfig
    {
        public string ID { get; set; }

        public string Secret { get; set; }
        public string PublicAPI { get; set; }
        public string PrivateAPI { get; set; }        
    }
}
