using System;
using SM.DataMappers.Common;

using BO = SM.BusinessObjects.Stuff;
using DM = SM.DataModels.StuffDataModel.Entities;

namespace SM.DataModels.StuffDataModel.DataMappers
{
	public class PersonDataMapper : DataMapper<BO.Person, DM.Person>
	{
		public override DM.Person Map(BO.Person businessObject)
		{
			throw new NotImplementedException();
		}

		public override BO.Person Map(DM.Person entity)
		{
			throw new NotImplementedException();
		}
	}
}