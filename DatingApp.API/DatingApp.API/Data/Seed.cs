using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Newtonsoft.Json;

namespace DatingApp.API.Data
{
    public class Seed
    {
        public static void SeedUsers(DataContext context)
        {
            if (!context.Users.Any())
            {
                var userData = File.ReadAllText("Data/UserSeedData.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);
                foreach (var user in users)
                {
                    user.Username = user.Username.ToLower();
                    user.SetPassword("password");

                    context.Users.Add(user);
                }

                context.SaveChanges();
            }
        }
    }
}
