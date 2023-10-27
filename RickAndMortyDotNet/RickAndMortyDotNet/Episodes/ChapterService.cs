using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Interdimensional
{
    internal static class ChapterService
    {
        private static readonly HttpClient httpClient = new HttpClient { BaseAddress = new Uri("https://rickandmortyapi.com/api/") };

        public static async Task<Chapter> GetEpisodesAsync(int id)
        {
            var response = await httpClient.GetStringAsync($"episode/{id}");
            Chapter episode = JsonConvert.DeserializeObject<Chapter>(response);
            return episode;
        }

        public static async Task<InfoObject<Chapter>> GetAllEpisodesAsync(int page)
        {
            var response = await httpClient.GetStringAsync($"episode/?page={page}");
            return JsonConvert.DeserializeObject<InfoObject<Chapter>>(response);
        }

        public static async Task<List<Chapter>> GetMultipleEpisodesAsync(params int[] ids)
        {
            string idString = string.Join(",", ids);
            var response = await httpClient.GetStringAsync($"episode/{idString}");
            List<Chapter> episodes = JsonConvert.DeserializeObject<List<Chapter>>(response);
            return episodes;
        }

        public static async Task<List<Chapter>> FilterEpisodeAsync(ChapterFilter filter)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            if (!string.IsNullOrEmpty(filter.Name))
                query["name"] = filter.Name;
            if (!string.IsNullOrEmpty(filter.Episode))
                query["episode"] = filter.Episode;

            string queryString = query.ToString();

            var response = await httpClient.GetStringAsync($"episode/?{queryString}");
            var rootObject = JsonConvert.DeserializeObject<InfoObject<Chapter>>(response);

            return rootObject.Results;
        }
    }
}
