using System;
using System.IO;
using System.Reflection;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

using SM.DataModels.StuffDataModel;
using SM.DataModels.StuffDataModel.Entities;

namespace SM.Tests.DataModels
{
	public class StuffDbContextIntegrationTests : IDisposable
	{
		private const string TEST_TRAIT = "Integration";

		private IServiceCollection _serviceCollection;

		// Setup (just a regular old constructor)
		public StuffDbContextIntegrationTests()
		{
			// Initialize class level tests here...

			var currentWorkingDirectory = Path.GetDirectoryName(typeof(StuffDbContextIntegrationTests).GetTypeInfo().Assembly.Location);
			var builder = new ConfigurationBuilder()
								.SetBasePath(currentWorkingDirectory + @"\..\..\..")
								.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
								.AddEnvironmentVariables();

			_serviceCollection = new ServiceCollection();

			InitializeServices(_serviceCollection);
		}

		// Teardown (minimal implementation of IDisposable)
		public void Dispose()
		{
			// Cleanup stuff here (tear down)

			Cleanup();

			_serviceCollection = null;
		}

		[Fact, Trait(TEST_TRAIT, TEST_TRAIT)]
		public void StuffDbContext_AddStuff()
		{
			var test = ConstructTestObject();
			var owner = ConstructPerson();
			var stuff = ConstructStuff(owner);

			test.AddPerson(owner);
			test.AddStuff(stuff);

			test.Commit();

			var actual = test.GetStuff(stuff.Id);

			Assert.NotNull(actual);
			Assert.Equal(stuff.Id, actual.Id);
			Assert.Equal(stuff.Name, actual.Name);
		}

		[Fact, Trait(TEST_TRAIT, TEST_TRAIT)]
		public void StuffDbContext_AddPerson_GetPerson()
		{
			var test = ConstructTestObject();
			var person = ConstructPerson();

			var result = test.AddPerson(person);

			Assert.True(result);        // Kind of a bogus assertion.

			test.Commit();

			person = test.GetPerson(person.LastName);

			Assert.NotNull(person);

			person = test.GetPerson(person.Id);

			Assert.NotNull(person);
		}

		[Fact, Trait(TEST_TRAIT, TEST_TRAIT)]
		public void StuffDbContext_AddPerson_NoCommit_GetPerson()
		{
			var test = ConstructTestObject();
			var person = ConstructPerson();

			var result = test.AddPerson(person);

			Assert.True(result);		// Kind of a bogus assertion.

			//test.Commit();			// You need this commit to make the change persist to the database.

			person = test.GetPerson(person.LastName);

			Assert.Null(person);
		}

		//----==== PRIVATE ====--------------------------------------------------------------------

		private void Cleanup()
		{
			var test = ConstructTestObject();

			test.Statuses.RemoveRange(test.Statuses);
			test.Stuff.RemoveRange(test.Stuff);
			test.People.RemoveRange(test.People);

			test.Commit();
		}

		private Person ConstructPerson()
		{
			return new Person
			{
				FirstName = "Parker",
				LastName = "Smart",
				Email = "psmart@spilledmilk.com"
			};
		}

		private Stuff ConstructStuff(Person owner)
		{
			return new Stuff()
			{
				Name = "Iron Man 3",
				Description = "Paramount, Film, Blu-ray",
				ImageUrl = "http://www.dvd-covers.org/d/313520-2/Iron_Man_3_-_Custom2.jpg",
				Owner = owner
			};
		}

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