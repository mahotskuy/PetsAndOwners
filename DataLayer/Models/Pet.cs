using System;
using System.Collections.Generic;
using System.Text;

namespace DBManager.Models
{
    class Pet
    {
		public Guid PetId { get; set; }

		public string PetName { get; set; }

		public Guid PetTypeId { get; set; }

		public string PetType { get; set; }

		public Guid OwnerId { get; set; }
    }
}
