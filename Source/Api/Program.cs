using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace SamMiller.Mumba.Api
{
    /// <summary>
    /// The Main Method
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Runs the program by building the webhost
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// The webhost builder and args
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
