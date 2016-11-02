using System;
using SM.DataMappers.Common;

using BO = SM.BusinessObjects.Stuff;
using DM = SM.DataModels.StuffDataModel.Entities;

namespace SM.DataModels.StuffDataModel.DataMappers
{
	public class StatusDataMapper : DataMapper<BO.Status, DM.Status>
	{
		public override DM.Status Map(BO.Status businessObject)
		{
			throw new NotImplementedException();
		}

		public override BO.Status Map(DM.Status entity)
		{
			throw new NotImplementedException();
		}
	}
}