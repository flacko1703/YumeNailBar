using Newtonsoft.Json;
using RestSharp;
using YumeNailBar.Application.DTO;

namespace YumeNailBar.Blazor.Services;

public class CustomerService : ICustomerService
{
    private readonly IRestClient _restClient;
    private readonly string _baseUrl = "http://localhost:5000/";

    public CustomerService()
    {
        _restClient = new RestClient("http://localhost:5072/");
    }

    public async Task<CustomerDto> GetById(Guid id)
    {
        var request = new RestRequest($"api/Client/{id}");
        var response = await _restClient.GetAsync<CustomerDto>(request);
        return response;
    }

    public async Task AddAsync(CustomerDto customer)
    {
        var json = JsonConvert.SerializeObject(customer);
        var request = new RestRequest("api/Client", Method.Post);

        var response = await _restClient.PostAsync(request.AddBody(json));
        var qwer = response;
    }
}