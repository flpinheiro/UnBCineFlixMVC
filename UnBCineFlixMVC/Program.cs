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
    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new UnBCineFlixContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //var movies = context.Movies.ToList();
            //foreach (var movie in movies)
            //{
            //    movie.Rating = new UnBCineFlix.Models.Rating { Id = 1 };
            //    context.Movies.Update(movie);
            //}
            //context.SaveChanges();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
