using Demo.Models;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(Demo.Startup))]
namespace Demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

			// CreateDatabaseIfNotExists is the default initializer if not specified
			Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());

			// NullDatabaseInitializer will turn off migration. 
			// You need to manually create the data tables
			//Database.SetInitializer<ApplicationDbContext>(new NullDatabaseInitializer<ApplicationDbContext>());
		}
	}
}
