using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interdimensional
{
    public sealed class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Dimension { get; set; }
        public string[] Residents { get; set; }
        public string Url { get; set; }
        public string Created { get; set; }
    }
}
