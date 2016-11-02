using SM.DataMappers.Common;

using BO = SM.BusinessObjects.Stuff;
using DM = SM.DataModels.StuffDataModel.Entities;

namespace SM.DataModels.StuffDataModel.DataMappers
{
	public class StatusDataMapper : DataMapper<BO.Status, DM.Status>
	{
		// The methods are constructing the objects and manually assigning the values. "brute force"

		public override DM.Status Map(BO.Status businessObject)
		{
			return new DM.Status
			{
				DateApproved = businessObject.DateApproved,
				DateCheckedIn = businessObject.DateCheckedIn,
				DateCheckedOut = businessObject.DateCheckedOut,
				DateRequested = businessObject.DateRequested,
				Id = businessObject.Id
			};
		}

		public override BO.Status Map(DM.Status entity)
		{
			return new BO.Status
			{
				DateApproved = entity.DateApproved,
				DateCheckedIn = entity.DateCheckedIn,
				DateCheckedOut = entity.DateCheckedOut,
				DateRequested = entity.DateRequested,
				Id = entity.Id
			};
		}
	}
}