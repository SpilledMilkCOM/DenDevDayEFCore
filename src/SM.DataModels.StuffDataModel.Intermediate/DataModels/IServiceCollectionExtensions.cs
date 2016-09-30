﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace SM.DataModels.StuffDataModel.Intermediate
{
    public static class IServiceCollectionExtensions
    {
		private const string CONNECTION_STRING = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=StuffIntermediate";

	    public static void AddStuff(this IServiceCollection services)
	    {
		    services.AddScoped<IStuffDataModel, StuffDbContext>();

			services.AddEntityFramework().AddDbContext<StuffDbContext>(options => options.UseSqlServer(CONNECTION_STRING));
		}
	}
}