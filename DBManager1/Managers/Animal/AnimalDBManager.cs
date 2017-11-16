using System;
using System.Collections.Generic;
using System.Linq;
using DBManager.DataConnection;
using DBManager.DBManagerCommon;

namespace DBManager.Managers.Animal
{
	public class AnimalDBManager
	{
		 public static List<Models.Animal> GetAllAnimals()
	    {
			List<Models.Animal> animals = new List<Models.Animal>();

		    using (var context = new PetsAndOwnersDataContext(DBManagerHelper.ConnectionString))
		    {
			    animals = context.Animals.Select(a => new Models.Animal
			    {
				    AnimalPk = a.AnimalPK,
				    Name = a.Name
			    }).ToList();
		    }

			return animals;
		}

		public static List<Models.Common.DropDown<Guid>> GetAnimalsDropDown()
		{
			using (var context = new PetsAndOwnersDataContext(DBManagerHelper.ConnectionString))
			{
				return context.Animals.Select(a => new Models.Common.DropDown<Guid>
				{
					ItemPk = a.AnimalPK,
					Value = a.Name
				}).ToList();
			}
		}

		public static void DeleteAnimalById(Guid animalPk)
		{
			using (var context = new PetsAndOwnersDataContext())
			{
				var animal = context.Animals.FirstOrDefault(o => o.AnimalPK == animalPk);
				if (animal != null)
					context.Animals.DeleteOnSubmit(animal);
				context.SubmitChanges();
			}
		}

		public static Models.Animal GetAnimalById(Guid animalPk)
		{
			var animal = new PetsAndOwnersDataContext().Animals.FirstOrDefault(o => o.AnimalPK.Equals(animalPk)) ??
						new DataConnection.Animal();
			return new Models.Animal
			{
				AnimalPk = animal.AnimalPK,
				Name = animal.Name
			};
		}

		public static void AddAnimal(DataConnection.Animal animal)
		{
			using (var context = new PetsAndOwnersDataContext())
			{
				context.Animals.InsertOnSubmit(animal);
				context.SubmitChanges();
			}
		}

		public static void UpdateAnimal (DataConnection.Animal animal)
		{
			using (var context = new PetsAndOwnersDataContext())
			{
				var dbItem = context.Animals.First(o => o.AnimalPK == animal.AnimalPK);
				dbItem.Name = animal.Name;
				context.SubmitChanges();
			}
		}
	}
}
