using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Interdimensional
{
    public static class Location
    {

        private static readonly HttpClient httpClient = new HttpClient { BaseAddress = new Uri("https://rickandmortyapi.com/api/") };

        public static async Task<Area> GetLocationAsync(int id)
        {
            var response = await httpClient.GetStringAsync($"Location/{id}");
            Area location = JsonConvert.DeserializeObject<Area>(response);
            return location;
        }

        public static async Task<InfoObject<Area>> GetAllEpisodesAsync()
        {
            var response = await httpClient.GetStringAsync($"location");
            return JsonConvert.DeserializeObject<InfoObject<Area>>(response);
        }

        public static async Task<List<Area>> GetMultipleEpisodesAsync(params int[] ids)
        {
            string idString = string.Join(",", ids);
            var response = await httpClient.GetStringAsync($"location/{idString}");
            List<Area> location = JsonConvert.DeserializeObject<List<Area>>(response);
            return location;
        }

        public static async Task<List<Area>> FilterEpisodeAsync(LocationsFilter filter)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            if (!string.IsNullOrEmpty(filter.Name))
                query["name"] = filter.Name;
            if (!string.IsNullOrEmpty(filter.Type))
                query["type"] = filter.Type;
            if (!string.IsNullOrEmpty(filter.Dimension))
                query["dimension"] = filter.Dimension;

            string queryString = query.ToString();

            var response = await httpClient.GetStringAsync($"location/?{queryString}");
            var rootObject = JsonConvert.DeserializeObject<InfoObject<Area>>(response);

            return rootObject.Results;
        }
    }
}
