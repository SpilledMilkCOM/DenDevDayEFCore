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
			// This really isn't needed, because the connection string is hard coded in the in the extension method AddStuff()

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
		public void StuffDbContext_AddPerson_GetPerson_AcrossContexts()
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

			// Verify that the object was persisted, by using a completely different context.

			var test2 = ConstructTestObject();

			var person2 = test2.GetPerson(person.Id);

			Assert.Equal(person.Id, person2.Id);
		}

		[Fact, Trait(TEST_TRAIT, TEST_TRAIT)]
		public void StuffDbContext_AddStatus()
		{
			var test = ConstructTestObject();
			var owner = ConstructPerson();
			var stuff = ConstructStuff(owner);
			var requestor = ConstructPerson2();
			var status = ConstructStatus(requestor, stuff);

			test.AddPerson(owner);
			test.AddStuff(stuff);
			test.AddStatus(status);

			test.Commit();

			var actual = test.GetStatus(status.Id);

			Assert.NotNull(actual);
			Assert.Equal(status.Id, actual.Id);
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

			Assert.NotNull(stuff.Owner);
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

		private Person ConstructPerson2()
		{
			return new Person
			{
				FirstName = "Bruce",
				LastName = "Wayne",
				Email = "batman@spilledmilk.com"
			};
		}

		private Status ConstructStatus(Person requestor, Stuff stuff)
		{
			return new Status
			{
				Requestor = requestor,
				Stuff = stuff
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