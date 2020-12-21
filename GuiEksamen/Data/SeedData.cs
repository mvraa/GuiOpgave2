using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using GuiEksamen.Models.Entities;
using static BCrypt.Net.BCrypt;

namespace GuiEksamen.Data
{
    public static class DbUtilities
    {
        public const int BcryptWorkfactor = 10;

        public static void SeedData(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Accounts.Any())
                SeedAccounts(context);
            if (!context.Managers.Any())
                SeedManagers(context);
        }

        static void SeedAccounts(ApplicationDbContext context)
        {
            context.Accounts.AddRange(
                // Seed manager
                new EfAccount
                {
                    Email = "boss@m.dk",
                    PwHash = HashPassword("asdfQWER", BcryptWorkfactor),
                    IsManager = true
                },
                // Seed some models
                new EfAccount
                {
                    Email = "nc@m.dk",
                    PwHash = HashPassword("Pas123", BcryptWorkfactor),
                    IsManager = false
                },
                new EfAccount
                {
                    Email = "hc@m.dk",
                    PwHash = HashPassword("Pas123", BcryptWorkfactor),
                    IsManager = false
                },
                new EfAccount
                {
                    Email = "al@m.dk",
                    PwHash = HashPassword("Pas123", BcryptWorkfactor),
                    IsManager = false
                },
                new EfAccount
                {
                    Email = "jk@m.dk",
                    PwHash = HashPassword("Pas123", BcryptWorkfactor),
                    IsManager = false
                }
                );
            context.SaveChanges();
        }

        static void SeedManagers(ApplicationDbContext context)
        {
            context.Managers.Add(
                new EfManager
                {
                    EfAccountId = 1,
                    Email = "boss@m.dk",
                    FirstName = "The",
                    LastName = "Boss",
                    
                });
                context.SaveChanges();
        }
    }
}
