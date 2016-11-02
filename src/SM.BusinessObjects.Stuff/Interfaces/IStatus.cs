using System;

namespace SM.BusinessObjects.Stuff.Interfaces
{
	public interface IStatus
	{
		int Id { get; set; }
		DateTime? DateApproved { get; set; }
		DateTime? DateCheckedOut { get; set; }
		DateTime? DateRequested { get; set; }
		Person Requestor { get; set; }
		Stuff Stuff { get; set; }
	}
}