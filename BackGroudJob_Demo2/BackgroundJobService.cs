
using Newtonsoft.Json.Linq;
using System.Text.Json;

public class BackgroundJobService : IHostedService
{
    private readonly ILogger<BackgroundJobService> _logger;
    private readonly HttpClient Clinet = new HttpClient();

    public BackgroundJobService(ILogger<BackgroundJobService> logger)
    {
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Start");
        var getUsers = await Clinet.GetAsync("https://localhost:7156/api/User");
        if (!getUsers.IsSuccessStatusCode) { _logger.LogInformation("Error API"); }

        var contentGetUsers = await getUsers.Content.ReadAsStringAsync();
        if (contentGetUsers.Length <= 0)
        {
            _logger.LogInformation("User null");
            return;
        }
        var json = JObject.Parse(contentGetUsers);

        _logger.LogInformation("Data from API1: {@data}", json);
        return;

        //var dbInfoUsers = JsonSerializer.Deserialize<List<UserInfo>>(contentGetUsers);



        //while (true)
        //{
        //    _logger.LogInformation("Time at:" + DateTime.UtcNow);
        //    Task.Delay(1000).Wait();
        //}
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Stop");
        return Task.CompletedTask;
    }
}