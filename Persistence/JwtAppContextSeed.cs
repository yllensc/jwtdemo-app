using System.Globalization;
using System.Reflection;
using CsvHelper;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Persistence;

public class JwtAppContextSeed
{
public static async Task SeedAsync(JwtAppContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            var ruta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (!context.Brands.Any())
            {
                using (var readerBrands = new StreamReader(ruta + @"/Data/Csvs/marcas.csv"))
                {
                    using (var csvBrands = new CsvReader(readerBrands, CultureInfo.InvariantCulture))
                    {
                        var brands = csvBrands.GetRecords<Brand>();
                        context.Brands.AddRange(brands);
                        await context.SaveChangesAsync();
                    }
                }
            }

            if (!context.Categories.Any())
            {
                using (var readerCategories = new StreamReader(ruta + @"/Data/Csvs/categorias.csv"))
                {
                    using (var csvCategories = new CsvReader(readerCategories, CultureInfo.InvariantCulture))
                    {
                        var categories = csvCategories.GetRecords<Category>();
                        context.Categories.AddRange(categories);
                        await context.SaveChangesAsync();
                    }
                }
            }

            if (!context.Products.Any())
            {
                using (var readerProducts = new StreamReader(ruta + @"/Data/Csvs/productos.csv"))
                {
                    using (var csvProducts = new CsvReader(readerProducts, CultureInfo.InvariantCulture))
                    {
                        var listadoProductsCsv = csvProducts.GetRecords<Product>();

                        List<Product> Products = new List<Product>();
                        foreach (var item in listadoProductsCsv)
                        {
                            Products.Add(new Product
                            {
                                Id = item.Id,
                                ProductName = item.ProductName,
                                Price = item.Price,
                                CreatedDate = item.CreatedDate,
                                IdCategory = item.IdCategory,
                                IdBrand = item.IdBrand                        
                            });
                        }

                        context.Products.AddRange(Products);
                        await context.SaveChangesAsync();
                    }
                }
            }


        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<JwtAppContext>();
            logger.LogError(ex.Message);
        }
    }

    public static async Task SeedRolesAsync(JwtAppContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!context.Rols.Any())
            {
                var roles = new List<Rol>()
                        {
                            new Rol{Id=1, Nombre="Aministrator"},
                            new Rol{Id=2, Nombre="Customer"},
                            new Rol{Id=3, Nombre="Employee"},
                        };
                context.Rols.AddRange(roles);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<JwtAppContext>();
            logger.LogError(ex.Message);
        }
    }
}