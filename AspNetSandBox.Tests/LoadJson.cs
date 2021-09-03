using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AspNetSandBox.Tests
{
    static class LoadJson
    {

        public static string LoadJsonFromResource(string filename)
        {
            var assembly = Assembly.GetCallingAssembly();
            var assemblyName = assembly.GetName().Name;
            var resourceName = $"{assemblyName}.{filename}.json";
            var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using (var tr = new StreamReader(resourceStream))
            {
                return tr.ReadToEnd();
            }
        }
    }
}
