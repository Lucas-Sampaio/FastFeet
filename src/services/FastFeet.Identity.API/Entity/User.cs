using Microsoft.AspNetCore.Identity;
using System;

namespace FastFeet.Identity.API.Entity
{
    public class User : IdentityUser
    {
        public User() { }
        public User(string userName) : base(userName) { }
     
        public string Nome { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
