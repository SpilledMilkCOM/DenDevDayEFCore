using System;
using SM.DataMappers.Common;

using BO = SM.BusinessObjects.Stuff;
using DM = SM.DataModels.StuffDataModel.Entities;

namespace SM.DataModels.StuffDataModel.DataMappers
{
	public class StuffDataMapper : DataMapper<BO.Stuff, DM.Stuff>
	{
		public override DM.Stuff Map(BO.Stuff businessObject)
		{
			throw new NotImplementedException();
		}

		public override BO.Stuff Map(DM.Stuff entity)
		{
			throw new NotImplementedException();
		}
	}
}