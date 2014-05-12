using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SubHub.DAL;
using SubHub.Models;
using System.Collections.Generic;
using System.Linq;

namespace SubHub.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Subtitle> Subtitles { get; set; }
        public virtual ICollection<SubtitleRating> SubtitleRatings { get; set; }
        public virtual ICollection<RequestRating> RequestRatings { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }



    public class IdentityManager
    {
        public bool RoleExists(string name)
        {
            var rm = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new SubHubContext()));
            return rm.RoleExists(name);
        }


        public bool CreateRole(string name)
        {
            var rm = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new SubHubContext()));
            var idResult = rm.Create(new IdentityRole(name));
            return idResult.Succeeded;
        }

        public bool UserExists(string name)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new SubHubContext()));
            return um.FindByName(name) != null;
        }

        public ApplicationUser GetUser(string name)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new SubHubContext()));
            return um.FindByName(name);
        }

        public ApplicationUser GetUserById(string id)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new SubHubContext()));
            return um.FindById(id);
        }

        public bool CreateUser(ApplicationUser user, string password)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new SubHubContext()));
            var idResult = um.Create(user, password);
            return idResult.Succeeded;
        }

        public bool AddUserToRole(string userId, string roleName)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new SubHubContext()));
            var idResult = um.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }

    }
}
