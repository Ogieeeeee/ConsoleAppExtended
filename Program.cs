Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(BuildConfig())
    .WriteTo.Console()
    .WriteTo.File("test.txt")
    .WriteTo.Seq("http://localhost:5341/")
    .CreateLogger();

IHost host = Host.CreateDefaultBuilder(args)
    .UseSerilog()
    .ConfigureServices(services =>
    {
        services.AddTransient<MyClass>();
    })
    .Build();

var t = host.Services.GetService<MyClass>();
t?.DoSomething();

await host.RunAsync();

static IConfigurationRoot BuildConfig()
{
    var config = new ConfigurationBuilder().AddJsonFile(Directory.GetCurrentDirectory() + @"\appsettings.json").AddEnvironmentVariables().Build();
    return config;
}