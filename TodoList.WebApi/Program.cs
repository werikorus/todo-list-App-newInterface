namespace TodoList.WebApi;

public static class Program
{
    public static void Main(params string[] args) => CreateWebHostBuilder(args).Build().Run();

    private static IHostBuilder CreateWebHostBuilder(params string[] args)
        => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
}