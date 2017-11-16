using System;
using System.Runtime.InteropServices;

namespace PetsAndOwners.Models
{
	public class PetModel: IBaseModel
	{
		public Guid PetPk { get; set; }

		public string PetName { get; set; }

		public Guid AnimalPk { get; set; }

		public string PetType { get; set; }

		public Guid? OwnerPk { get; set; }

		public string OwnerFullName { get; set; }

		public void PopulateData(object o)
		{
			var pet = (DBManager.Models.Pet) o;

			PetPk = pet.PetPk;
			PetName = pet.PetName;
			AnimalPk = pet.AnimalPk;
			PetType = pet.PetType;
			OwnerPk = pet.OwnerPk;
			OwnerFullName = pet.OwnerFullName;
		}
	}
}