using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisCursosXamarin
{
    class Product
    {
        public string nombre { get; set; }
        public string cantidad { get; set; }
        public string imagen { get; set; }
        public string precioMillar { get; set; }
        public JArray items { get; set; }
    }
}
