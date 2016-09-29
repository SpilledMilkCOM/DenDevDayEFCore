using Microsoft.EntityFrameworkCore;

using SM.DataModels.Stuff.Entities;

namespace SM.DataModels.Stuff
{
	public interface IStuffDataModel
    {
		DbSet<Person> People { get; set; }

		DbSet<Status> Statuses { get; set; }

		DbSet<Entities.Stuff> Stuff { get; set; }

		bool AddPerson(Person person);

		bool AddStuff(Entities.Stuff stuff);

		void Commit();

		Person GetPerson(int id);

		Entities.Stuff GetStuff(int id);
    }
}