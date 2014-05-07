﻿using Microsoft.AspNet.Identity.EntityFramework;

namespace SubHub.Repositories
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        // Hér getum við bætt við eigindum við notendur, þ.á.m. vensl við önnur model
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("SubHubContext")
        {
        }
    }
}