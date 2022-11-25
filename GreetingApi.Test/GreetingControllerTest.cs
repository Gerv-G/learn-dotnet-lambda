using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GreetingApi.Controllers;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace GreetingApi.Test;

public class GreetingControllerTest : IAsyncLifetime
{
    private readonly Mock<ILogger<GreetingController>> _mockLogger = new();
    
    private HttpClient _httpClient = null!;

    public async Task InitializeAsync()
    {
        var hostBuilder = Program.CreateHostBuilder(Array.Empty<string>())
            .ConfigureWebHost(webHostBuilder => webHostBuilder.UseTestServer())
            .ConfigureServices((_, services) => services.AddSingleton(_mockLogger.Object));

        var host = await hostBuilder.StartAsync();
        _httpClient = host.GetTestClient();
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }

    [Fact]
    public async Task GetHelloWorld_ShouldReturnHelloWorld()
    {
        var response = await _httpClient.GetAsync("greeting/hello-world");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var responseContent = await response.Content.ReadAsStringAsync();
        Assert.Equal("Hello World", responseContent);
    }
}