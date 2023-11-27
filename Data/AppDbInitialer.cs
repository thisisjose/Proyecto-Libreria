using libreria_JSVE.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Writers;
using System;
using System.Linq;

namespace libreria_JSVE.Data
{
    public class AppDbInitialer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) 
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Titulo = "Gimme sum' of that",
                        Descripcion = "A true love story",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genero = "Amor",
                        CoverUrl = "https...",
                        DateAdded = DateTime.Now,
                    },
                     new Book()
                     {
                         Titulo = "Gimme sum' of that",
                         Descripcion = "A true love story",
                         IsRead = true,
                         DateRead = DateTime.Now.AddDays(-10),
                         Rate = 4,
                         Genero = "Amor",
                         CoverUrl = "https...",
                         DateAdded = DateTime.Now,
                     });
                    context.SaveChanges();
                }
            }
        }

    }
}
