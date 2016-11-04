using System;

using SM.BusinessObjects.Stuff.Interfaces;

namespace SM.BusinessObjects.Stuff
{
	internal class Stuff : IStuff
    {
		public int Id { get; set; }

		public IPerson Owner { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string ImageUrl { get; set; }

		public DateTime DateAdded { get; set; }
	}
}
