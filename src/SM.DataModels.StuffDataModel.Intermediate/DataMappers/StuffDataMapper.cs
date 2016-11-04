using Microsoft.Extensions.DependencyInjection;

using SM.DataMappers.Common;

// Since this mapper is more like a mediator, then treat these objects equally and alias them BOTH!

using BO = SM.BusinessObjects.Stuff.Interfaces;
using DM = SM.DataModels.StuffDataModel.Entities;

namespace SM.DataModels.StuffDataModel.DataMappers
{
	public class StuffDataMapper : DataMapper<BO.IStuff, DM.Stuff>
	{
		public StuffDataMapper(IServiceCollection serviceCollection)
			: base(serviceCollection)
		{
		}

		// The methods are constructing the objects and manually assigning the values. "brute force"

		public override DM.Stuff Map(BO.IStuff businessObject)
		{
			return new DM.Stuff
			{
				DateAdded = businessObject.DateAdded,
				Description = businessObject.Description,
				Id = businessObject.Id,
				ImageUrl = businessObject.ImageUrl,
				Name = businessObject.Name
			};
		}

		public override BO.IStuff Map(DM.Stuff entity)
		{
			// The construction might be slower than doing a "new", but the flexibility of using the IoC Container is nice.
			// If you are shooting for PURE SPEED, then stick with doing a "new".

			var result = ServiceProvider.GetRequiredService<BO.IStuff>();

			result.DateAdded = entity.DateAdded;
			result.Description = entity.Description;
			result.Id = entity.Id;
			result.ImageUrl = entity.ImageUrl;
			result.Name = entity.Name;

			return result;
		}
	}
}