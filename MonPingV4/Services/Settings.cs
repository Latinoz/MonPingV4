using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;
using MonPingV4.Models;
using System.Linq;
using System.Reflection;

namespace MonPingV4.Services
{
    public class Settings
    {
        public void SaveHostsToJson(List<string> items)                          //Метод сохранения всех значений ячеек, для ввода ip адреса
        {
            List<Json> iphosts = new List<Json>();

            foreach(string str in items)
            {
                iphosts.Add(new Json(str));
            }
            
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Json>));

            using (FileStream fs = new FileStream("hosts.json", FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, iphosts);
            }
        }

        public List<string> LoadHostsFromJson()                                //Загрузка списка ip адресов из json
        {
            string path = @"hosts.json";

            List<string> result = null;

            if (File.Exists(path))
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Json>));

                List<Json> iphostsload = (List<Json>)jsonFormatter.ReadObject(fs);
                    
                result = iphostsload.Select(x => x.Hosts).ToList();

                }

            return result;

        }

        public string GetNetCoreVersion()
        {
            var assembly = typeof(System.Runtime.GCSettings).GetTypeInfo().Assembly;
            var assemblyPath = assembly.CodeBase.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            int netCoreAppIndex = Array.IndexOf(assemblyPath, "Microsoft.NETCore.App");
            if (netCoreAppIndex > 0 && netCoreAppIndex < assemblyPath.Length - 2)
                return assemblyPath[netCoreAppIndex + 1];
            return null;
        }
    }
}
