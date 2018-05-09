using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Qp.Api.Models;
using System.Reflection;

namespace ResourceChecker
{
    class Program
    {
        public static void PrintPropertiesToFile(string FileNameContains){
            var assembly = typeof(Qp.Api.Models.QpApiModelsAssemblyMarker).Assembly;
            IEnumerable<Type> types = null;
            HashSet<string> PropertyNames=new HashSet<string>();
            types = assembly.GetTypes().Where(x => x.Name.Contains("Request"));
            foreach (var x in types)
            {
                foreach (var y in x.GetProperties())
                {
                    PropertyNames.Add(y.Name);
                    Console.WriteLine(x);
                }
            }
            System.IO.File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+@"Write.txt", PropertyNames);
        }
    }
}
