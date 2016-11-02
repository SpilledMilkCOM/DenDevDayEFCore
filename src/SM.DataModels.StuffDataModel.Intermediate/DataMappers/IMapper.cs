using System.Collections.Generic;

namespace SM.DataMappers.Common
{
	public interface IMapper<T1, T2>
	{
		// TODO: Change this to the main interface.  IDataMapper

		T2 Map(T1 source);

		T1 Map(T2 source);

		List<T2> Map(IEnumerable<T1> entities);

		List<T1> Map(IEnumerable<T2> entities);
	}
}