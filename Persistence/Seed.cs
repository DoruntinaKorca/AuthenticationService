using AuthenticationService.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.Persistence
{
    public class Seed
    {
        public static async Task SeedUsers(AuthenticationContext context, UserManager<User> userManager) { 
           /*
                var users = new List<User>
                {
                    new User{
                      //  UserName="DoruntinaK",
                        Email="dk40651@ubt-uni.net"
                    },
                     new User{
                       // UserName="RilindB",
                        Email="rb47139@ubt-uni.net"
                    },
                      new User{
                      //  UserName="EndritM", 
                        Email="em47593@ubt-uni.net" 
                      },
                      new User{
                    
                        Email="medina.shamolli@ubt-uni.net" 
                      },
                      new User{
                    
                        Email="ramiz.hoxha@ubt-uni.net" 
                      },
                      new User{
             
                        Email="arber.kadriu@ubt-uni.net" 
                      },
                      new User{
                  
                        Email="sramadani@ubt-uni.net" 
                      }
                };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$word1");
                }
            */
            await context.SaveChangesAsync();
        }
    }
}
