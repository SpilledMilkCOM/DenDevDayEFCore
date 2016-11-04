using System;

using SM.BusinessObjects.Stuff.Interfaces;

namespace SM.BusinessObjects.Stuff
{
	internal class Status : IStatus
	{
		public int Id { get; set; }

		public DateTime? DateApproved { get; set; }

		public DateTime? DateCheckedIn { get; set; }

		public DateTime? DateCheckedOut { get; set; }

		public DateTime? DateRequested { get; set; }

		public IPerson Requestor { get; set; }

		public IStuff Stuff { get; set; }
	}
}