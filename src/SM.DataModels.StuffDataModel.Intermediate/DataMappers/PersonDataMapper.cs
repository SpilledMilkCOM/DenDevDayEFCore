using Microsoft.Extensions.DependencyInjection;

using SM.DataMappers.Common;
using SM.DataModels.StuffDataModel.DataMappers.Interfaces;

// Since this mapper is more like a mediator, then treat these objects equally and alias them BOTH!

using BO = SM.BusinessObjects.Stuff.Interfaces;
using DM = SM.DataModels.StuffDataModel.Entities;

namespace SM.DataModels.StuffDataModel.DataMappers
{
	public class PersonDataMapper : DataMapper<BO.IPerson, DM.Person>, IPersonDataMapper
	{
		public PersonDataMapper(IServiceCollection serviceCollection)
			: base(serviceCollection)
		{
		}

		// The methods are constructing the objects and manually assigning the values. "brute force"

		public override DM.Person Map(BO.IPerson businessObject)
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

		public override BO.IPerson Map(DM.Person entity)
		{
			// The construction might be slower than doing a "new", but the flexibility of using the IoC Container is nice.
			// If you are shooting for PURE SPEED, then stick with doing a "new".

			var result = ServiceProvider.GetRequiredService<BO.IPerson>();

			result.DateJoined = entity.DateJoined;
			result.Email = entity.Email;
			result.FirstName = entity.FirstName;
			result.Id = entity.Id;
			result.LastName = entity.LastName;

			return result; ;
		}
	}
}