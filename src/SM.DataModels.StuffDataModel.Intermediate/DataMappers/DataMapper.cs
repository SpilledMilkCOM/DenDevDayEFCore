using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace SM.DataMappers.Common
{
	public abstract class DataMapper<TBizObj, TDataEntity> : IMapper<TBizObj, TDataEntity>
	{
		// This class will grow as needed to incorporate the majority of the "typical" mappings.
		// TODO: Use reflection to do the property name mappings
		// Possibly inject the KIND of mapping that will be done.

		public DataMapper(IServiceCollection serviceCollection)
		{
			// This will effectively take a snapshot of the current state of the service collection,
			// so all of the needed objects should be defined up to this point.
			// Build this service provider here so you're NOT building during every single map call.

			ServiceProvider = serviceCollection.BuildServiceProvider();
		}

		protected IServiceProvider ServiceProvider { get; set; }

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