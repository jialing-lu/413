using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _413.Models
{
    public class AppIdentityDBContext : IdentityDbContext<IdentityUser>
    {
      public AppIdentityDBContext(DbContextOptions options) : base(options)
        {

        }
    }
}
