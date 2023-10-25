using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RickAndMortyDotNet.Character
{
    public class Character 
    {
        private readonly HttpClient httpClient;

        public Character()
        {
            httpClient = new HttpClient { BaseAddress = new Uri("https://rickandmortyapi.com/api/") };
        }


        public async Task<CharacterModel> GetCharacterAsync(int id)
        {
           var response = await httpClient.GetStringAsync($"{id}");
           CharacterModel character = JsonConvert.DeserializeObject<CharacterModel>(response);
           return character;
        }

        public async Task<InfoObject<CharacterModel>> GetAllCharacterAsync()
        {
            var response = await httpClient.GetStringAsync($"character");
            return JsonConvert.DeserializeObject<InfoObject<CharacterModel>>(response);
        }

        public async Task<List<CharacterModel>> GetMultipleCharactersAsync(params int[] ids)
        {
            string idString = string.Join(",", ids);
            var response = await httpClient.GetStringAsync($"{idString}");
            List<CharacterModel> characters = JsonConvert.DeserializeObject<List<CharacterModel>>(response);
            return characters;
        }

        public async Task<List<CharacterModel>> FilterCharactersAsync(CharacterFilter filter)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            if (!string.IsNullOrEmpty(filter.Name))
                query["name"] = filter.Name;
            if (!string.IsNullOrEmpty(filter.Status))
                query["status"] = filter.Status;
            if (!string.IsNullOrEmpty(filter.Species))
                query["species"] = filter.Species;
            if (!string.IsNullOrEmpty(filter.Type))
                query["type"] = filter.Type;
            if (!string.IsNullOrEmpty(filter.Gender))
                query["gender"] = filter.Gender;

            string queryString = query.ToString();

            var response = await httpClient.GetStringAsync($"character/?{queryString}");
            var rootObject = JsonConvert.DeserializeObject<InfoObject<CharacterModel>>(response);

            return rootObject.Results;
        }

    }
}
