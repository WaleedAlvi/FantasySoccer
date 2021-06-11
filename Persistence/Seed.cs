using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Persons.Any()) return;

            var persons = new List<Person>
            {
                new Person
                {
                    FirstName = "Waleed",
                    LastName = "Alvi",
                    DateOfBirth = new DateTime(1992, 2, 16),
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                }
            };

            await context.Persons.AddRangeAsync(persons);
            await context.SaveChangesAsync();
        }
    }
}