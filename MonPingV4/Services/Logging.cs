using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace MonPingV4.Services
{
    class Logging
    {
        public static void DoLog(string ip, string text)
        {
            using (StreamWriter w = File.AppendText(ip + ".txt"))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                w.WriteLine("  ");
                w.WriteLine(":{0}", text);
                w.WriteLine("-------------------------------");

            }
        }
    }
}
