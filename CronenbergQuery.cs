using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interdimensional
{
    public static class CronenbergQuery
    {
        public static Actor GetActor(int id)
        {
            return CharacterService.GetCharacterAsync(id).GetAwaiter().GetResult();
        }

        public static Actor GetActorRandom()
        {
            return CharacterService.GetRandomCharacterAsync().GetAwaiter().GetResult();
        }

        public static InfoObject<Actor> GetAllActor(int page)
        {
            return CharacterService.GetAllCharacterAsync(page).GetAwaiter().GetResult();
        }

        public static List<Actor> GetMultipleActor(int[] ids)
        {
            return CharacterService.GetMultipleCharactersAsync(ids).GetAwaiter().GetResult();
        }

        public static List<Actor> GetFilterActor(ActorFilter filter)
        {
            return CharacterService.FilterCharactersAsync(filter).GetAwaiter().GetResult();
        }

        public static Chapter GetChapter(int id)
        {
            return ChapterService.GetEpisodesAsync(id).GetAwaiter().GetResult();    
        }

        public static InfoObject<Chapter> GetAllChapter(int page)
        {
            return ChapterService.GetAllEpisodesAsync(page).GetAwaiter().GetResult();
        }

        public static List<Chapter> GetMultipleChapter(int[] ids)
        {
            return ChapterService.GetMultipleEpisodesAsync(ids).GetAwaiter().GetResult();
        }

        public static List<Chapter> GetFilterChapter(ChapterFilter filter)
        {
            return ChapterService.FilterEpisodeAsync(filter).GetAwaiter().GetResult();
        }

        public static Location GetLocation(int id)
        {
            return LocationService.GetLocationAsync(id).GetAwaiter().GetResult();
        }

        public static InfoObject<Location> GetAllLocation(int page)
        {
            return LocationService.GetAllLocationAsync(page).GetAwaiter().GetResult();
        }

        public static List<Location> GetMultipleLocation(int[] ids)
        {
            return LocationService.GetMultipleLocationAsync().GetAwaiter().GetResult();
        }

        public static List<Location> GetFilterLocation(LocationsFilter filter)
        {
            return LocationService.FilterLocationAsync(filter).GetAwaiter().GetResult();
        }

    }
}
