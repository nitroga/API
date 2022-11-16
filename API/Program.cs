using RestSharp;
using System.Text.Json;
using System.Net;

Console.WriteLine("Choose category (string)\nCategoriess:\nPeople\nPlanets\nFilms\nStarships\n");
string category = Console.ReadLine().ToLower();

Console.WriteLine("Input request (number)");
string count = Console.ReadLine();

Console.Clear();

Console.WriteLine($"Request: {category}/{count}\n");

RestClient client = new("https://swapi.py4e.com/api/");
RestRequest request = new($"{category}/{count}");
RestResponse response = client.GetAsync(request).Result;

SWAPI sw = JsonSerializer.Deserialize<SWAPI>(response.Content);

if (response.StatusCode == HttpStatusCode.OK) {
    Console.WriteLine(response.Content);
    Console.WriteLine(sw.name);
}

else {
    Console.WriteLine("404 Error: Item not found");
}

Console.ReadLine();