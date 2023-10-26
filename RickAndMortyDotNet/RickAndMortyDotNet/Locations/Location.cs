using Newtonsoft.Json;
using RickAndMortyDotNet.Episodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RickAndMortyDotNet.Locations
{
    public class Location
    {

        private readonly HttpClient httpClient;

        public Location()
        {
            httpClient = new HttpClient { BaseAddress = new Uri("https://rickandmortyapi.com/api/") };
        }

        public async Task<LocationsModel> GetLocationAsync(int id)
        {
            var response = await httpClient.GetStringAsync($"Location/{id}");
            LocationsModel location = JsonConvert.DeserializeObject<LocationsModel>(response);
            return location;
        }

        public async Task<InfoObject<LocationsModel>> GetAllEpisodesAsync()
        {
            var response = await httpClient.GetStringAsync($"location");
            return JsonConvert.DeserializeObject<InfoObject<LocationsModel>>(response);
        }

        public async Task<List<LocationsModel>> GetMultipleEpisodesAsync(params int[] ids)
        {
            string idString = string.Join(",", ids);
            var response = await httpClient.GetStringAsync($"location/{idString}");
            List<LocationsModel> location = JsonConvert.DeserializeObject<List<LocationsModel>>(response);
            return location;
        }

        public async Task<List<LocationsModel>> FilterEpisodeAsync(LocationsFilter filter)
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
            var rootObject = JsonConvert.DeserializeObject<InfoObject<LocationsModel>>(response);

            return rootObject.Results;
        }
    }
}
