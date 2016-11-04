using System;

using SM.BusinessObjects.Stuff.Interfaces;
using SM.DataModels.StuffDataModel.DataMappers.Interfaces;
using SM.DataModels.StuffDataModel.Repositories;

namespace SM.DataModels.StuffDataModel.Intermediate.Repositories
{
	public class StuffRepository : IStuffRepository
    {
	    private IStuffDataModel _dataModel;
	    private IPersonDataMapper _personMapper;

		// The respository carries out more intelligent processes using the data in the DbContext

		public StuffRepository(IStuffDataModel dataModel, IPersonDataMapper personMapper)
		{
			_dataModel = dataModel;
			_personMapper = personMapper;
		}

		public bool Add(IPerson person)
		{
			return _dataModel.AddPerson(_personMapper.Map(person));
		}

		public void ApproveRequest(int statusId)
		{
			throw new NotImplementedException();
		}

		public void CancelCheckOut(int statusId)
		{
			throw new NotImplementedException();
		}

		public void CancelRequest(int statusId)
		{
			throw new NotImplementedException();
		}

		public void CheckInStuff(IStuff stuff)
		{
			throw new NotImplementedException();
		}

		public void CheckOutStuff(IStuff stuff)
		{
			throw new NotImplementedException();
		}

		public IPerson Get(string email)
		{
			throw new NotImplementedException();
		}

		public IPerson Get(int personId)
		{
			throw new NotImplementedException();
		}

		/// <summary> Requesting stuff STARTS the workflow and adds a row to the status table.
		/// </summary>
		/// <param name="stuffId">The ID of Stuff</param>
		/// <param name="personRequestingId">The ID of the Person requesting the Stuff</param>
		public void RequestStuff(int stuffId, int personRequestingId)
		{
			// Do we need a full blown Stuff object?  Probably not.

			throw new NotImplementedException();
		}
	}
}