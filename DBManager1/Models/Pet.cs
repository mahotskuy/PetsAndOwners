using System;
using System.Collections.Generic;
using System.Text;

namespace DBManager.Models
{
	public class Pet
    {
		public Guid PetPk { get; set; }

		public string PetName { get; set; }

		public Guid AnimalPk { get; set; }

		public string PetType { get; set; }

		public Guid? OwnerPk { get; set; }

		public string OwnerFullName { get; set; }
    }
}
