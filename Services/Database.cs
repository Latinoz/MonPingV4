using System;
using System.Collections.Generic;
using System.Text;
using MonPingV4.Models;

namespace MonPingV4.Services
{
    public class Database
    {
        public IEnumerable<HostsItem> GetItems() => new[]
        {
           new HostsItem { Address = "127.0.0.1" },
           new HostsItem { Address = "127.0.0.2" },
           new HostsItem { Address = "127.0.0.3", IsChecked = true },
       };
    }
}
