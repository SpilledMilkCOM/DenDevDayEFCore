using System;
using System.IO;
using System.Reflection;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

using SM.DataModels.Stuff;
using SM.DataModels.Stuff.Entities;

namespace SM.Tests.DataModels
{
	public class StuffDbContextIntegrationTests : IDisposable
	{
		private const string TEST_TRAIT = "Integration";

		private IServiceCollection _serviceCollection;

		// Setup (just a regular old constructor)
		public StuffDbContextIntegrationTests()
		{
			// Initialize stuff here

			var currentWorkingDirectory = Path.GetDirectoryName(typeof(StuffDbContextIntegrationTests).GetTypeInfo().Assembly.Location);
			var builder = new ConfigurationBuilder()
								.SetBasePath(currentWorkingDirectory + @"\..\..\..")
								.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
								.AddEnvironmentVariables();

			_serviceCollection = new ServiceCollection();

			InitializeServices(_serviceCollection);
		}

		// Teardown
		public void Dispose()
		{
			// Cleanup stuff here (tear down)

			_serviceCollection = null;
		}

		[Fact, Trait(TEST_TRAIT, TEST_TRAIT)]
		public void StuffDbContext_AddPerson()
		{
			var test = ConstructTestObject();
			var person = new Person
			{
				FirstName = "Parker",
				LastName = "Smart",
				Email = "psmart@spilledmilk.com"
			};

			var result = test.AddPerson(person);

			Assert.True(result);

			test.Commit();
		}

		[Fact, Trait(TEST_TRAIT, TEST_TRAIT)]
		public void StuffDbContext_GetPerson()
		{
			var test = ConstructTestObject();

			var actual = test.GetPerson(1);

			Assert.Null(actual);
		}

		//----==== PRIVATE ====--------------------------------------------------------------------

		private IStuffDataModel ConstructTestObject()
		{
			var serviceProvider = _serviceCollection.BuildServiceProvider();

			return serviceProvider.GetRequiredService<IStuffDataModel>();
		}

		private void InitializeServices(IServiceCollection services)
		{
			services.AddStuff();
		}
	}
}