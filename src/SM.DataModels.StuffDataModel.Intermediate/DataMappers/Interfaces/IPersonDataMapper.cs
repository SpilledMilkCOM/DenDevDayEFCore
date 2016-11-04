using System.Collections.Generic;

using BO = SM.BusinessObjects.Stuff.Interfaces;
using DM = SM.DataModels.StuffDataModel.Entities;

namespace SM.DataModels.StuffDataModel.DataMappers.Interfaces
{
	public interface IPersonDataMapper
	{
		DM.Person Map(BO.IPerson businessObject);

		BO.IPerson Map(DM.Person entity);

		List<BO.IPerson> Map(IEnumerable<DM.Person> entities);

		List<DM.Person> Map(IEnumerable<BO.IPerson> businessObjects);
	}
}
