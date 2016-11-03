using SM.BusinessObjects.Stuff;

namespace SM.DataModels.StuffDataModel.Repositories
{
	public interface IStuffRepository
    {
	    bool Add(Person person);

	    void ApproveRequest(int statusId);

	    void CancelCheckOut(int statusId);

	    void CancelRequest(int statusId);

		void CheckInStuff(Stuff stuff);

		void CheckOutStuff(Stuff stuff);

	    Person Get(int personId);

	    Person Get(string email);

	    void RequestStuff(int stuffId, int personId);
    }
}