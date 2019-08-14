using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadoCidade.Util
{
    public class ReadFile
    {
        public static JArray Read(string filepath)
        {
            return JArray.Parse(File.ReadAllText(filepath, Encoding.GetEncoding(28591)));
        }
    }
}
