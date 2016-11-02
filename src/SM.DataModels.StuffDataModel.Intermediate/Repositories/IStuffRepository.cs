using SM.BusinessObjects.Stuff;

namespace SM.DataModels.StuffDataModel.Repositories
{
	public interface IStuffRepository
    {
	    bool Add(Person person);

	    Person Get(int personId);

	    Person Get(string email);

	    void RequestStuff(int stuffId, int personId);
    }
}