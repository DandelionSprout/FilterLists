using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace FilterLists.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://localhost:5001;")
                .UseStartup<Startup>()
                .Build();
        }
    }
}