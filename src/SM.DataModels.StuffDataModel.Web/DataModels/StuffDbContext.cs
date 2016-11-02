using System;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using SM.DataModels.StuffDataModel.Entities;

namespace SM.DataModels.StuffDataModel
{
	public class StuffDbContext : DbContext, IStuffDataModel
	{
		// Since this DbContext isfor the basic example, this contains "repository" type methods

		public StuffDbContext(DbContextOptions<StuffDbContext> options)
			: base(options) { }

		public DbSet<Person> People { get; set; }

		public DbSet<Status> Statuses { get; set; }

		public DbSet<Stuff> Stuff { get; set; }

		public bool AddPerson(Person person)
		{
			// Setting the date might be something that a repository would do.
			person.DateJoined = DateTime.Now;

			People.Add(person);

			return true;
		}

		public bool AddStatus(Status status)
		{
			// Setting the date might be something that a repository would do.
			status.DateRequested = DateTime.Now;		// This starts the "workflow"

			Statuses.Add(status);

			return true;
		}

		public bool AddStuff(Stuff stuff)
		{
			// Setting the date might be something that a repository would do.
			stuff.DateAdded = DateTime.Now;

			Stuff.Add(stuff);

			return true;
		}

		public void Commit()
		{
			SaveChanges();
		}

		public Person GetPerson(int id)
		{
			return People.FirstOrDefault(item => item.Id == id);
		}

		public Person GetPerson(string lastName)
		{
			return People.FirstOrDefault(item => item.LastName == lastName);
		}

		public Status GetStatus(int id)
		{
			// TODO: Need to include Owner.

			return Statuses.FirstOrDefault(item => item.Id == id);
		}

		public Stuff GetStuff(int id)
		{
			// TODO: Need to include Owner.

			return Stuff.FirstOrDefault(item => item.Id == id);
		}

		//----==== PROTECTED ====------------------------------------------------------------------

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Old way...
			//modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

			modelBuilder.Model.RemoveEntityType("OneToManyCascadeDeleteConvention");
		}
	}
}