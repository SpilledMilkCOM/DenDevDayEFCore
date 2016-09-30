using Microsoft.EntityFrameworkCore;

using SM.DataModels.StuffDataModel.Entities;

namespace SM.DataModels.StuffDataModel
{
	public interface IStuffDataModel
    {
		DbSet<Person> People { get; set; }

		DbSet<Status> Statuses { get; set; }

		DbSet<Stuff> Stuff { get; set; }

		bool AddPerson(Person person);

		bool AddStatus(Status status);

		bool AddStuff(Stuff stuff);

		void Commit();

		Person GetPerson(int id);

		Person GetPerson(string lastName);

		Status GetStatus(int id);

		Stuff GetStuff(int id);
	}
}