using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CTRL_Core.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new WebHostBuilder().UseKestrel().UseUrls("http://*:80").UseContentRoot(Directory.GetCurrentDirectory()).UseStartup<Startup>().Build().Run();
            //CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
