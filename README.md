# RickAndMortyDotNet

## from nuget

Install-Package RickAndMorty.Net.Api

## Usage And Methods

The Interdimensional library provides a set of methods to interact with the "Rick and Morty" universe by retrieving data about characters (referred to as "actors") and chapters. Here's how to use the library:

Getting Started
First, make sure to include the Interdimensional namespace in your file:
```csharp
using Interdimensional;

```
Get a Single Actor
Retrieve a specific actor by their ID:

```csharp
Actor actor = CronenbergQuery.GetActor(34);
```
Get a Random Actor
For a bit of unpredictability, fetch a random actor:

```csharp
Actor protaRandom = CronenbergQuery.GetActorRandom();
```
Get Multiple Actors
Get multiple actors by supplying an array of their IDs:

```csharp
int[] ids = { 57, 128 };
List<Actor> actors = CronenbergQuery.GetMultipleActor(ids);
```
Get All Actors with Pagination
Retrieve all actors, with the results paginated:
```csharp
InfoObject<Actor> info = CronenbergQuery.GetAllActor(3);
```
Get All Chapters with Pagination
Fetch all chapters in a paginated format:
```csharp
InfoObject<Chapter> chap = CronenbergQuery.GetAllChapter(3);
```
#Supporting Classes
InfoObject Class
The InfoObject<T> class is a generic class used for paginated results, providing the following properties:

Info: A property of type Info which includes metadata such as the current page number, total pages, and total number of items.

Results: A List<T> holding the results returned for the current page, where T can be an Actor or a Chapter depending on the query.

```csharp
public class InfoObject<T> where T : class
    {
        public Info Info { get; set; }

        public List<T> Results { get; set; }
    }
```



