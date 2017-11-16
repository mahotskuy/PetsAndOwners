using System;
using System.Collections.Generic;
using System.Linq;
using DBManager.DataConnection;
using DBManager.DBManagerCommon;
using PetShopCommon;
using Animal = DBManager.Models.Animal;

namespace DBManager.Managers.Pet
{
    public class PetDBManager
    {
	    public static List<Models.Pet> GetPetList()
	    {
		    using (var context = new PetsAndOwnersDataContext())
		    {
			    return (from pet in context.Pets
				    join animal in context.Animals on pet.AnimalPK equals animal.AnimalPK
				    join owner in context.Owners on pet.OwnerPK equals owner.OwnerPK into ownerGroup
					from item in ownerGroup.DefaultIfEmpty()
				    select new Models.Pet
				    {
					    PetPk = pet.PetPK,
					    AnimalPk = animal.AnimalPK,
					    PetName = pet.Name,
					    PetType = animal.Name,
					    OwnerPk = pet.OwnerPK.Value,
					    OwnerFullName = item == null ? TextResourse.txtNA : item.FirstName + " " + item.LastName
				    }).ToList();
		    }
	    }

		public static void DeletePetById(Guid petPk)
		{
			using (var context = new PetsAndOwnersDataContext())
			{
				var pet = context.Pets.FirstOrDefault(o => o.PetPK == petPk);
				if (pet != null)
				{
					context.Pets.DeleteOnSubmit(pet);
					context.SubmitChanges();
				}
			}
		}

		public static Models.Pet GetOwnerById(Guid petPk)
		{
			using (var context = new PetsAndOwnersDataContext())
			{
				return (from pet in context.Pets
					where pet.PetPK == petPk
					join animal in context.Animals on pet.AnimalPK equals animal.AnimalPK
					join owner in context.Owners on pet.OwnerPK equals owner.OwnerPK into ownerGroup
					from item in ownerGroup.DefaultIfEmpty()
					select new Models.Pet
					{
						PetPk = pet.PetPK,
						AnimalPk = animal.AnimalPK,
						PetName = pet.Name,
						PetType = animal.Name,
						OwnerPk = pet.OwnerPK.Value,
						OwnerFullName = item == null ? TextResourse.txtNA : item.FirstName + " " + item.LastName
					}).First();
			}
		}

		public static void UpdatePet(DataConnection.Pet item)
		{
			using (var context = new PetsAndOwnersDataContext())
			{
				var dbItem = context.Pets.First(o => o.PetPK == item.PetPK);
				dbItem.Name = item.Name;
				dbItem.AnimalPK = item.AnimalPK;
				dbItem.OwnerPK = item.OwnerPK;
				context.SubmitChanges();
			}
		}

		public static void AddPet(DataConnection.Pet pet)
		{
			using (var context = new PetsAndOwnersDataContext())
			{
				context.Pets.InsertOnSubmit(pet);
				context.SubmitChanges();
			}
		}
	}
}
