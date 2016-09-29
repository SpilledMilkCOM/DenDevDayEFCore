using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using SM.DataModels.Stuff.Entities;

namespace SM.DataModels.Stuff
{
	public class StuffDbContext : DbContext, IStuffDataModel
	{
		public StuffDbContext(DbContextOptions<StuffDbContext> options)
			: base(options) { }

		public DbSet<Person> People { get; set; }

		public DbSet<Status> Statuses { get; set; }

		public DbSet<Entities.Stuff> Stuff { get; set; }

		public bool AddPerson(Person person)
		{
			person.DateJoined = DateTime.Now;

			People.Add(person);

			return true;
		}

		public bool AddStuff(Entities.Stuff stuff)
		{
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

		public Entities.Stuff GetStuff(int id)
		{
			// TODO: Need to include Owner.

			return Stuff.FirstOrDefault(item => item.Id == id);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

			modelBuilder.Model.RemoveEntityType("OneToManyCascadeDeleteConvention");
		}
	}
}