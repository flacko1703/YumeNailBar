// See https://aka.ms/new-console-template for more information

using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using RestSharp;
using YumeNailBar.Application.DTO;
using YumeNailBar.Console;
using YumeNailBar.Domain.AggregateModels.CustomerAggregate;

try
{
    await GetProductAsync(Guid.Parse("1F389677-8D84-4423-8330-8BD4299643AA"));
    //await CreateProductAsync();
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}


static async Task CreateProductAsync()
{
    var client = new RestClient("https://localhost:32768/");
    var request = new RestRequest("api/Client", Method.Post);
    
    var response = await client.PostAsync(request.AddBody("{\"registration\":{\"appointmentDate\":\"2023-05-30T08:10:22.247Z\",\"procedures\":[{\"procedureKind\":1,\"price\":99999}],\"isCanceled\":false},\"name\":\"bbbbbbbbbbbbbbbbbb\",\"phoneNumber\":\"89999978855\",\"email\":\"11111@gmail.com\",\"comment\":\"qqqqqqqqqqqq\"}"));
    var content = response.Content; 
    var response2 = client.Post<Customer>(request);
}

static async Task GetProductAsync(Guid id)
{
    var client = new RestClient("https://localhost:5001/");
    var request = new RestRequest($"api/Client/{id}", Method.Get);

    var response = await client.GetAsync<CustomerDto>(request);
}