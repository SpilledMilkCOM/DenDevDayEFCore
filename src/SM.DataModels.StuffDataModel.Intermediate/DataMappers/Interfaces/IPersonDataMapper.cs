using System.Collections.Generic;

using BO = SM.BusinessObjects.Stuff;
using DM = SM.DataModels.StuffDataModel.Entities;

namespace SM.DataModels.StuffDataModel.DataMappers.Interfaces
{
	public interface IPersonDataMapper
	{
		DM.Person Map(BO.Person businessObject);
		BO.Person Map(DM.Person entity);
		List<BO.Person> Map(IEnumerable<DM.Person> entities);
		List<DM.Person> Map(IEnumerable<BO.Person> businessObjects);
	}
}
