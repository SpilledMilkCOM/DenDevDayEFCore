using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace SM.DataModels.StuffDataModel
{
    public static class IServiceCollectionExtensions
    {
		// Reading in the connection string from the appsettings JSON file is more in the intermediate phase

		private const string CONNECTION_STRING = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Stuff";

	    public static void AddStuff(this IServiceCollection services)
	    {
		    services.AddScoped<IStuffDataModel, StuffDbContext>();

			services.AddEntityFramework().AddDbContext<StuffDbContext>(options => options.UseSqlServer(CONNECTION_STRING));
		}
	}
}