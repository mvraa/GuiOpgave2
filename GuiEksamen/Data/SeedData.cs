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
            if (!context.Users.Any())
                SeedManagers(context);
        }

        static void SeedAccounts(ApplicationDbContext context)
        {
            context.Accounts.AddRange(
                // Seed manager
                new EfAccount
                {
                    Email = "bruger@bruger.dk",
                    PwHash = HashPassword("pass1", BcryptWorkfactor),
                    IsManager = true
                },
                new EfAccount
                {
                    Email = "test@test.dk",
                    PwHash = HashPassword("pass2", BcryptWorkfactor),
                    IsManager = true
                }
            );
            context.SaveChanges();
        }

        static void SeedManagers(ApplicationDbContext context)
        {
            context.Users.AddRange(
                new EfUser
                {
                    EfAccountId = 1,
                    Email = "bruger@bruger.dk",
                    FirstName = "Mathias",
                    LastName = "Vraa",
                    Freq = 2000,
                    Duration = 11
                },
                new EfUser
                {
                    EfAccountId = 2,
                    Email = "test@test.dk",
                    FirstName = "Bente",
                    LastName = "Bent",
                    Freq = 5000,
                    Duration = 10
                }
                );
                context.SaveChanges();
        }
    }
}
