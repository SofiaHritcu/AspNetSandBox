﻿using AspNetSandBox.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetSandBox.Data
{
    public static class DataTools
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var applicationDbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                if (applicationDbContext.Book.Any())
                {
                    Console.WriteLine("The books are there !");
                }
                else
                {
                    Console.WriteLine("There are no books !");
                    applicationDbContext.Add(new Book
                    {
                        Title = "War and Peace",
                        Author = "Lev Tolstoi",
                        Language = "English",
                    });
                    applicationDbContext.Add(new Book
                    {
                        Title = "Crime and Punishment",
                        Author = "Feodor Dostoievski",
                        Language = "English",
                    });
                    applicationDbContext.SaveChanges();
                }
            }
        }
    }
}
