using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Interdimensional
{
    public static class LocationService
    {

        private static readonly HttpClient httpClient = new HttpClient { BaseAddress = new Uri("https://rickandmortyapi.com/api/") };

        public static async Task<Location> GetLocationAsync(int id)
        {
            var response = await httpClient.GetStringAsync($"Location/{id}");
            Location location = JsonConvert.DeserializeObject<Location>(response);
            return location;
        }

        public static async Task<InfoObject<Location>> GetAllLocationAsync(int page)
        {
            var response = await httpClient.GetStringAsync($"location/?page={page}");
            return JsonConvert.DeserializeObject<InfoObject<Location>>(response);
        }

        public static async Task<List<Location>> GetMultipleLocationAsync(params int[] ids)
        {
            string idString = string.Join(",", ids);
            var response = await httpClient.GetStringAsync($"location/{idString}");
            List<Location> location = JsonConvert.DeserializeObject<List<Location>>(response);
            return location;
        }

        public static async Task<List<Location>> FilterLocationAsync(LocationsFilter filter)
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
            var rootObject = JsonConvert.DeserializeObject<InfoObject<Location>>(response);

            return rootObject.Results;
        }
    }
}
