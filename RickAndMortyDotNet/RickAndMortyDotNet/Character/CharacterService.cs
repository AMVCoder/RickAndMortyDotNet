using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Interdimensional
{
    internal static class CharacterService 
    {
        private static readonly HttpClient httpClient = new HttpClient { BaseAddress = new Uri("https://rickandmortyapi.com/api/") };
  
      
        public static async Task<Actor> GetCharacterAsync(int id)
        {
           var response = await httpClient.GetStringAsync($"character/{id}");
           Actor character = JsonConvert.DeserializeObject<Actor>(response);
           return character;
        }

        public static async Task<InfoObject<Actor>> GetAllCharacterAsync(int page)
        {
            var response = await httpClient.GetStringAsync($"character/?page={page}");
            return JsonConvert.DeserializeObject<InfoObject<Actor>>(response);
        }

        public static async Task<List<Actor>> GetMultipleCharactersAsync(params int[] ids)
        {
            string idString = string.Join(",", ids);
            var response = await httpClient.GetStringAsync($"character/{idString}");
            List<Actor> characters = JsonConvert.DeserializeObject<List<Actor>>(response);
            return characters;
        }

        public static async Task<List<Actor>> FilterCharactersAsync(ActorFilter filter)
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
            var rootObject = JsonConvert.DeserializeObject<InfoObject<Actor>>(response);

            return rootObject.Results;
        }

        public static async Task<Actor> GetRandomCharacterAsync()
        {
            int randompage = new Random().Next(0, 42);
            // Obtén el número total de personajes
            InfoObject<Actor> allInfo = await GetAllCharacterAsync(randompage);
            int totalCharacters = allInfo.Info.Count;

            //  Genera un número aleatorio
            Random rand = new Random();
            int randomId = rand.Next(1, totalCharacters + 1); // Los IDs comienzan desde 1

            // Usa el ID aleatorio para obtener un personaje
            var randomCharacter = await GetCharacterAsync(randomId);

            return randomCharacter;
        }

    }
}
