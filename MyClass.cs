namespace ConsoleAppExtended;

public class MyClass
{
    private readonly ILogger<MyClass> _logger;
    private readonly IConfiguration _configuration;
    public MyClass(ILogger<MyClass> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public void DoSomething()
    {
        _logger.LogInformation($"Hello from my console app. Config: {_configuration.GetValue<int>("test")}");
    }

}
