using System;

using SM.BusinessObjects.Stuff;
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

		public bool Add(Person person)
		{
			return _dataModel.AddPerson(_personMapper.Map(person));
		}

		public Person Get(string email)
		{
			throw new NotImplementedException();
		}

		public Person Get(int personId)
		{
			throw new NotImplementedException();
		}

		public void RequestStuff(int stuffId, int personId)
		{
			throw new NotImplementedException();
		}
	}
}