using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace MonPingV4.Models
{    
    [DataContract]
    public class Json
    {
        [DataMember]
        public string Hosts { get; set; }
        public Json(string hosts)
        {
            Hosts = hosts;
        }
    }
    
}
