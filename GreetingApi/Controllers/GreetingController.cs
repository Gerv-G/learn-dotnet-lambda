using Microsoft.AspNetCore.Mvc;

namespace GreetingApi.Controllers;

[ApiController]
[Route("greeting")]
public class GreetingController : ControllerBase
{
    private readonly ILogger<GreetingController> _logger;

    public GreetingController(ILogger<GreetingController> logger)
    {
        _logger = logger;
    }

    [HttpGet("hello-world")]
    public string HelloWorld()
    {
        _logger.Log(LogLevel.Information, "Serving request for /greeting/hello-world");
        return "Hello World";
    }
}
