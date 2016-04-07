using DeanerySystem.Domain.Concrete;
using DeanerySystem.Domain.Entities.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeanerySystem.UI.Startup))]
namespace DeanerySystem.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }


		private void createRolesandUsers() {
			//var context = new DeaneryDbContext();

			//var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
			//var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


			// In Startup iam creating first Admin Role and creating a default Admin User   
			//if (!roleManager.RoleExists("SuperAdmin")) {

			//	// first we create Admin rool  
			//	var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
			//	role.Name = "SuperAdmin";
			//	roleManager.Create(role);

			//	//Here we create a Admin super user who will maintain the website                 

			//	var user = new ApplicationUser();
			//	user.UserName = "Rector";
			//	//user.Email = "syedshanumcain@gmail.com";

			//	string userPWD = "123qwe!@#QWE";

			//	var chkUser = UserManager.Create(user, userPWD);

			//	//Add default User to Role Admin  
			//	if (chkUser.Succeeded) {
			//		var result1 = UserManager.AddToRole(user.Id, "SuperAdmin");

			//	}
			//}

			//// creating Creating Manager role   
			//if (!roleManager.RoleExists("Manager")) {
			//	var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
			//	role.Name = "Manager";
			//	roleManager.Create(role);

			//}

			//// creating Creating Employee role   
			//if (!roleManager.RoleExists("Employee")) {
			//	var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
			//	role.Name = "Employee";
			//	roleManager.Create(role);

			//}
		}
	}
}
