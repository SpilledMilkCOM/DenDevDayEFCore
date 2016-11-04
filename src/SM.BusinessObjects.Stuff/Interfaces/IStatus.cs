using System;

namespace SM.BusinessObjects.Stuff.Interfaces
{
	public interface IStatus
	{
		int Id { get; set; }

		DateTime? DateApproved { get; set; }

		DateTime? DateCheckedIn { get; set; }

		DateTime? DateCheckedOut { get; set; }

		DateTime? DateRequested { get; set; }

		IPerson Requestor { get; set; }

		IStuff Stuff { get; set; }
	}
}