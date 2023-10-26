using Newtonsoft.Json;
using RickAndMortyDotNet.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RickAndMortyDotNet.Episodes
{
    public class Episodes
    {
        private readonly HttpClient httpClient;

        public Episodes()
        {
            httpClient = new HttpClient { BaseAddress = new Uri("https://rickandmortyapi.com/api/") };
        }

        public async Task<EpisodesModel> GetEpisodesAsync(int id)
        {
            var response = await httpClient.GetStringAsync($"episode/{id}");
            EpisodesModel episode = JsonConvert.DeserializeObject<EpisodesModel>(response);
            return episode;
        }

        public async Task<InfoObject<EpisodesModel>> GetAllEpisodesAsync()
        {
            var response = await httpClient.GetStringAsync($"episode");
            return JsonConvert.DeserializeObject<InfoObject<EpisodesModel>>(response);
        }

        public async Task<List<EpisodesModel>> GetMultipleEpisodesAsync(params int[] ids)
        {
            string idString = string.Join(",", ids);
            var response = await httpClient.GetStringAsync($"episode/{idString}");
            List<EpisodesModel> episodes = JsonConvert.DeserializeObject<List<EpisodesModel>>(response);
            return episodes;
        }

        public async Task<List<EpisodesModel>> FilterEpisodeAsync(EpisodesFilter filter)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            if (!string.IsNullOrEmpty(filter.Name))
                query["name"] = filter.Name;
            if (!string.IsNullOrEmpty(filter.Episode))
                query["episode"] = filter.Episode;

            string queryString = query.ToString();

            var response = await httpClient.GetStringAsync($"episode/?{queryString}");
            var rootObject = JsonConvert.DeserializeObject<InfoObject<EpisodesModel>>(response);

            return rootObject.Results;
        }
    }
}
