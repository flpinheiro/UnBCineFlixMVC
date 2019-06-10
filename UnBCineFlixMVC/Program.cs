using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using UnBCineFlix.DAL;

namespace UnBCineFlixMVC
{
    class Program
    {
        public static void Main(string[] args)
        {
            //var context = new UnBCineFlixContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((HostingContext, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddIniFile("config.ini", optional: true, reloadOnChange: true);
                config.AddJsonFile("appsettings.json",optional:true,reloadOnChange:true);
            })
                .UseStartup<Startup>();
    }
}
