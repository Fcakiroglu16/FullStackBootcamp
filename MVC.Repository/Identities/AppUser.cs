using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MVC.Repository.Identities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string? City { get; set; }


        public static AppUser Create(string email, string userName, string city)
        {
            return new AppUser()
            {
                Email = email,
                City = city,
                UserName = userName
            };
        }
    }
}