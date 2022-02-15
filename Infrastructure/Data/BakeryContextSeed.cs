using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class BakeryContextSeed
    {
        public static async Task SeedAsync(BakeryContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                if (!context.Sweets.Any())
                {
                    var sweetsData = File.ReadAllText( "../Infrastructure/Data/SeedData/sweets.json");
                    
                    var sweets = JsonSerializer.Deserialize<List<Sweet>>(sweetsData);

                    foreach (var item in sweets)
                    {
                        context.Sweets.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

               
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<BakeryContext>();
                logger.LogError(ex.Message);
            }
        }
    }
}