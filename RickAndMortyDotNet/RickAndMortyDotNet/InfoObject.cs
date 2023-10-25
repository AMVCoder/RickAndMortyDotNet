using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyDotNet
{
    public sealed class InfoObject<T>  where T : class
    {
        public Info Info { get; set; }
        public List<T> Results { get; set; }
    }

    public class Info
    {
        public int Count { get; set; }
        public int Pages { get; set; }
        public string Next { get; set; }
        public string Prev { get; set; }
    }
}
