using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ELSAPI.Entities;
using ELSAPI.Entities.OrderAggregate;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace ELSAPI.Data.SeedData
{
    public class DataContextSeed
    {
        public static async Task SeedAsync(DataContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                var path = @"../wwwroot/apiAssets/";

                if (!context.Products.Any())
                {
                    var data = File.ReadAllText(path + @"Products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(data);

                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                // if (!context.ProductColors.Any())
                // {
                //     var data = File.ReadAllText(path + @"ProductColors.json");

                //     var productColors = JsonSerializer.Deserialize<List<ProductColor>>(data);

                //     foreach (var item in productColors)
                //     {
                //         context.ProductColors.Add(item);
                //     }

                //     await context.SaveChangesAsync();
                // }

                // if (!context.ColorSizes.Any())
                // {
                //     var data = File.ReadAllText(path + @"ColorSizes.json");

                //     var colorSizes = JsonSerializer.Deserialize<List<ColorSize>>(data);

                //     foreach (var item in colorSizes)
                //     {
                //         context.ColorSizes.Add(item);
                //     }

                //     await context.SaveChangesAsync();
                // }

                if (!context.Districts.Any())
                {
                    var data = File.ReadAllText(path + @"Districts.json");

                    var districts = JsonSerializer.Deserialize<List<District>>(data);

                    foreach (var item in districts)
                    {
                        context.Districts.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Governorates.Any())
                {
                    var data = File.ReadAllText(path + @"Governorates.json");

                    var items = JsonSerializer.Deserialize<List<Governorate>>(data);

                    foreach (var item in items)
                    {
                        context.Governorates.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Categories.Any())
                {
                    var data = File.ReadAllText(path + @"Categories.json");

                    var items = JsonSerializer.Deserialize<List<Category>>(data);

                    foreach (var item in items)
                    {
                        context.Categories.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Sizes.Any())
                {
                    var data = File.ReadAllText(path + @"Sizes.json");

                    var items = JsonSerializer.Deserialize<List<Size>>(data);

                    foreach (var item in items)
                    {
                        context.Sizes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Colors.Any())
                {
                    var data = File.ReadAllText(path + @"Colors.json");

                    var items = JsonSerializer.Deserialize<List<Color>>(data);

                    foreach (var item in items)
                    {
                        context.Colors.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                
            }
            catch (System.Exception ex)
            {
                var logger = loggerFactory.CreateLogger<DataContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}