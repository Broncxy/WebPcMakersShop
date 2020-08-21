using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using WebPcMakers.Models;

[assembly: OwinStartupAttribute(typeof(WebPcMakers.Startup))]
namespace WebPcMakers
{
    public partial class Startup
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateUserAndRoles();
        }
        public void CreateUserAndRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                //create super admin role
                var role = new IdentityRole("Admin");
                roleManager.Create(role);

                //create default user
                var user = new ApplicationUser();
                user.UserName = "Admin@pc.com";
                user.Email = "Admin@pc.com";
                string pwd = "Admin@2019";

                var newuser = userManager.Create(user, pwd);

                if (newuser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");

                }
            }
        }

    }
}
