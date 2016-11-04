using Microsoft.Extensions.DependencyInjection;

using SM.BusinessObjects.Stuff.Interfaces;

namespace SM.BusinessObjects.Stuff
{
    public static class IServiceCollectionExtensions
    {
	    public static void AddStuffBusinessObjects(this IServiceCollection services)
	    {
		    services.AddTransient<IPerson, Person>();
			services.AddTransient<IStatus, Status>();
			services.AddTransient<IStuff, Stuff>();
		}
	}
}