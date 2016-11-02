using System;

using SM.BusinessObjects.Stuff.Interfaces;

namespace SM.BusinessObjects.Stuff
{
	public class Person : IPerson
	{
		public Person()
		{
		}

		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }

		public DateTime DateJoined { get; set; }

		[NonSerialized]
		public bool IsValid
		{
			get
			{
				return Id > 0
					&& !string.IsNullOrEmpty(FirstName)
					&& !string.IsNullOrEmpty(LastName);
			}
		}
	}
}