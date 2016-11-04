using Microsoft.Extensions.DependencyInjection;

using SM.BusinessObjects.Stuff.Interfaces;

namespace SM.BusinessObjects.Stuff
{
    public static class IServiceCollectionExtensions
    {
	    public static void AddStuffBusinessObjects(this IServiceCollection services)
	    {
			// These concrete objects are marked "internal" so this is a good way to construct them without KNOWING about them.
			// Adding these public interfaces to the IoC Container

		    services.AddTransient<IPerson, Person>();
			services.AddTransient<IStatus, Status>();
			services.AddTransient<IStuff, Stuff>();
		}
	}
}