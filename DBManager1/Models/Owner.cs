using System;

namespace DBManager.Models
{
    public class Owner
    {
		public Guid OwnerPk { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }
    }
}
