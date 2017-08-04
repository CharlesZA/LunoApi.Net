using System;
using System.Collections.Generic;
using System.Text;

namespace LunoApi.Net.Common
{
    public interface IConfig
    {        
        string ID { get; set; }
       
        string Secret { get; set; }

        string PublicAPIUrl { get; set; }        
    }
}
