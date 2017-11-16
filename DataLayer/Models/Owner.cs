using System;
using System.Collections.Generic;
using System.Text;

namespace DBManager.Models
{
    class Owner
    {
		public Guid OwnerID { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public int PetCount { get; set; }

    }
}
