using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

using SM.DataModels.StuffDataModel.DataMappers;
using SM.DataModels.StuffDataModel.DataMappers.Interfaces;

namespace SM.DataModels.StuffDataModel
{
    public static class IServiceCollectionExtensions
    {
		private const string CONNECTION_STRING = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=StuffIntermediate";

	    public static void AddStuff(this IServiceCollection services)
	    {
		    services.AddScoped<IStuffDataModel, StuffDbContext>();
		    services.AddScoped<IPersonDataMapper, PersonDataMapper>();

			services.AddEntityFramework().AddDbContext<StuffDbContext>(options => options.UseSqlServer(CONNECTION_STRING));
		}
	}
}