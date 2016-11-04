using SM.BusinessObjects.Stuff.Interfaces;

namespace SM.DataModels.StuffDataModel.Repositories
{
	public interface IStuffRepository
    {
	    bool Add(IPerson person);

	    void ApproveRequest(int statusId);

	    void CancelCheckOut(int statusId);

	    void CancelRequest(int statusId);

		void CheckInStuff(IStuff stuff);

		void CheckOutStuff(IStuff stuff);

	    IPerson Get(int personId);

	    IPerson Get(string email);

	    void RequestStuff(int stuffId, int personId);
    }
}