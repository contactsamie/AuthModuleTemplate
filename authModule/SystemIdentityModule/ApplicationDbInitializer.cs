

using System.Data.Entity;
using System.Web;
using SystemConfigurationSetUp;
using CuttingEdge.Conditions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace SystemIdentityModule
{
    // This is useful if you do not want to tear down the database each time you run the application.
    // public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    // This example shows you how to create a new database if the Model changes

    // public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext> 
    public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context) {
            InitializeIdentityForEF(context);
        
            base.Seed(context);
        }

        //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
        public static void InitializeIdentityForEF(ApplicationDbContext db) {
            
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            var name = CONFIGURATION.FromSettings.Retrieve.AdminAccount.UserName;
             var password = CONFIGURATION.FromSettings.Retrieve.AdminAccount.Password;
             const string roleName = "Admin";
            var email = CONFIGURATION.FromSettings.Retrieve.AdminAccount.EMail;

            Condition.Requires(password).IsNotNullOrEmpty();
            Condition.Requires(name).IsNotNullOrEmpty();
            Condition.Requires(email).IsNotNullOrEmpty();
            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null) {
                role = new IdentityRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            var user = userManager.FindByName(name);
            if (user == null) {
                user = new ApplicationUser { UserName = name, Email = email };
                var result = userManager.Create(user, password);
                //NOTE: CP User Excheque has pointed out what may be a
                //bug in the Identity 2.0 Sample project code
                //(this IS an alpha (now beta) release). 
                //When the initial admin user is created,
                //the EmailConfirmed property is never set, which compromises 
                //this user's ability to perform certain functions.
                //I've updated the code below to set the property. 
                // Set Email confirmation property (see note above):
                user.EmailConfirmed = true;
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name)) {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}