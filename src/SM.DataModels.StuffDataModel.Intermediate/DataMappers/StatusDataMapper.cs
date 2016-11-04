using Microsoft.Extensions.DependencyInjection;

using SM.DataMappers.Common;

// Since this mapper is more like a mediator, then treat these objects equally and alias them BOTH!

using BO = SM.BusinessObjects.Stuff.Interfaces;
using DM = SM.DataModels.StuffDataModel.Entities;

namespace SM.DataModels.StuffDataModel.DataMappers
{
	public class StatusDataMapper : DataMapper<BO.IStatus, DM.Status>
	{
		public StatusDataMapper(IServiceCollection serviceCollection)
			: base(serviceCollection)
		{
		}

		// The methods are constructing the objects and manually assigning the values. "brute force"

		public override DM.Status Map(BO.IStatus businessObject)
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

		public override BO.IStatus Map(DM.Status entity)
		{
			// The construction might be slower than doing a "new", but the flexibility of using the IoC Container is nice.
			// If you are shooting for PURE SPEED, then stick with doing a "new".

			var result = ServiceProvider.GetRequiredService<BO.IStatus>();

			result.DateApproved = entity.DateApproved;
			result.DateCheckedIn = entity.DateCheckedIn;
			result.DateCheckedOut = entity.DateCheckedOut;
			result.DateRequested = entity.DateRequested;
			result.Id = entity.Id;

			return result;
		}
	}
}