using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM.DataModels.StuffDataModel.Intermediate.Repositories
{
    public class StuffRepository
    {
	    private IStuffDataModel _dataModel;

		// The respository carries out more intelligent processes using the data in the DbContext

		public StuffRepository(IStuffDataModel dataModel)
		{
			_dataModel = dataModel;
		}
    }
}
