using System;

namespace SM.BusinessObjects.Stuff.Interfaces
{
	public interface IPerson
	{
		int Id { get; set; }

		string FirstName { get; set; }

		string LastName { get; set; }

		string Email { get; set; }

		DateTime DateJoined { get; set; }
	}
}