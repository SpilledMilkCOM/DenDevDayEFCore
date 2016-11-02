using SM.DataMappers.Common;

using BO = SM.BusinessObjects.Stuff;
using DM = SM.DataModels.StuffDataModel.Entities;

namespace SM.DataModels.StuffDataModel.DataMappers
{
	public class StuffDataMapper : DataMapper<BO.Stuff, DM.Stuff>
	{
		// The methods are constructing the objects and manually assigning the values. "brute force"

		public override DM.Stuff Map(BO.Stuff businessObject)
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

		public override BO.Stuff Map(DM.Stuff entity)
		{
			return new BO.Stuff
			{
				DateAdded = entity.DateAdded,
				Description = entity.Description,
				Id = entity.Id,
				ImageUrl = entity.ImageUrl,
				Name = entity.Name
			};
		}
	}
}