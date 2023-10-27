using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interdimensional
{
    public sealed class Chapter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonProperty("air_date")]
        public string AirDate { get; set; }
        public string EpisodeCode { get; set; }
        public List<string> Characters { get; set; }
        public string Url { get; set; }
        public string Created { get; set; }
    }
}
