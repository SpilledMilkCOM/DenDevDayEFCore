using System.Collections.Generic;

namespace SM.DataMappers.Common
{
	public abstract class DataMapper<TBizObj, TDataEntity> : IMapper<TBizObj, TDataEntity>
	{
		// This class will grow as needed to incorporate the majority of the "typical" mappings.
		// TODO: Use reflection to do the property name mappings
		// Possibly inject the KIND of mapping that will be done.

		public abstract TBizObj Map(TDataEntity entity);

		public abstract TDataEntity Map(TBizObj businessObject);

		public List<TBizObj> Map(IEnumerable<TDataEntity> entities)
		{
			List<TBizObj> result = new List<TBizObj>();

			// This is where the SQL will most likely be executed...  (when enumerating the data result set - entities)

			foreach (var dataEntity in entities)
			{
				var businessObject = Map(dataEntity);

				if (businessObject != null)
				{
					result.Add(businessObject);
				}
			}

			return result;
		}

		public List<TDataEntity> Map(IEnumerable<TBizObj> businessObjects)
		{
			List<TDataEntity> result = new List<TDataEntity>();

			foreach (var businessObject in businessObjects)
			{
				var dataEntity = Map(businessObject);

				if (dataEntity != null)
				{
					result.Add(dataEntity);
				}
			}

			return result;
		}
	}
}