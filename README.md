# RickAndMortyDotNet

# from nuget

Install-Package RickAndMorty.Net.Api

# Usage And Methods

```csharp

using Interdimensional;

Actor actor = CronenbergQuery.GetActor(34);

Actor protaRandom = CronenbergQuery.GetActorRandom();

int[] ids = { 57, 128 };
List<Actor> actors = CronenbergQuery.GetMultipleActor(ids);

InfoObject<Actor> info = CronenbergQuery.GetAllActor(3);

InfoObject<Chapter> chap = CronenbergQuery.GetAllChapter(3);

```csharp

public class InfoObject<T> where T : class
    {
        public Info Info { get; set; }

        public List<T> Results { get; set; }
    }
