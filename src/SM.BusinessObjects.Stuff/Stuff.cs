using System;

using SM.BusinessObjects.Stuff.Interfaces;

namespace SM.BusinessObjects.Stuff
{
	public class Stuff : IStuff
    {
		public int Id { get; set; }

		public Person Owner { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string ImageUrl { get; set; }

		public DateTime DateAdded { get; set; }
	}
}
