using System;

using SM.BusinessObjects.Stuff.Interfaces;

namespace SM.BusinessObjects.Stuff
{
	public class Status : IStatus
	{
		public int Id { get; set; }

		public DateTime? DateApproved { get; set; }

		public DateTime? DateCheckedOut { get; set; }

		public DateTime? DateRequested { get; set; }

		public Person Requestor { get; set; }

		public Stuff Stuff { get; set; }

	}
}