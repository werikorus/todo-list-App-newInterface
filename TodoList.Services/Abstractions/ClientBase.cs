using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TodoList.Services.Models;

namespace TodoList.Services.Abstractions;

public abstract class ClientBase<TClientModel>
    where TClientModel : ClientModel, new()
{
    private readonly IHttpClientFactory _httpClientFactory;

    protected ClientBase(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    protected abstract string ClientName { get; }
    protected abstract string EndPoint { get; }

    public async Task<TClientModel> GetAsync(CancellationToken cancellationToken)
    {
        var responseMessage = await GetClient().GetAsync(EndPoint, cancellationToken);

        return responseMessage.IsSuccessStatusCode
            ? await OnSucessAsync(responseMessage).ConfigureAwait(false)
            : OnError(responseMessage);
    }

    private HttpClient GetClient() => _httpClientFactory.CreateClient(ClientName);

    private static TClientModel OnError(HttpResponseMessage responseMessage)
        => new TClientModel { Result = responseMessage.ToString() };

    private static async Task<TClientModel> OnSucessAsync(HttpResponseMessage responseMessage)
    {
        var resultAsString = await responseMessage.Content.ReadAsStringAsync();
        return new TClientModel { Result = resultAsString };
    }
}
