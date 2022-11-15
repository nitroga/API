using RestSharp;
using System.Text.Json;
using System.Net;

RestClient pokeClient = new("https://pokeapi.co/api/v2/");
RestRequest request = new("pokemon/ditto");
RestResponse response = pokeClient.GetAsync(request).Result;

Pokemon p = JsonSerializer.Deserialize<Pokemon>(response.Content);

if (response.StatusCode == HttpStatusCode.OK) {
    Console.WriteLine(p.name);
    Console.WriteLine(p.weight);
    Console.WriteLine(p.is_default);
}

else {
    Console.WriteLine("Error: Pokemon probably not found");
}

Console.ReadLine();