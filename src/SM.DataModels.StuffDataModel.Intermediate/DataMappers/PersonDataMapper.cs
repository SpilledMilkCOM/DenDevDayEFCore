using System;
using SM.DataMappers.Common;

using BO = SM.BusinessObjects.Stuff;
using DM = SM.DataModels.StuffDataModel.Entities;

namespace SM.DataModels.StuffDataModel.DataMappers
{
	public class PersonDataMapper : DataMapper<BO.Person, DM.Person>
	{
		// The methods are constructing the objects and manually assigning the values. "brute force"

		public override DM.Person Map(BO.Person businessObject)
		{
			// These are pretty easy to create (intellisense REALLY helps)

			return new DM.Person()
			{
				DateJoined = businessObject.DateJoined,
				Email = businessObject.Email,
				FirstName = businessObject.FirstName,
				Id = businessObject.Id,
				LastName = businessObject.LastName
			};
		}

		public override BO.Person Map(DM.Person entity)
		{
			return new BO.Person()
			{
				DateJoined = entity.DateJoined,
				Email = entity.Email,
				FirstName = entity.FirstName,
				Id = entity.Id,
				LastName = entity.LastName
			};
		}
	}
}