using System;
using DBManager.Models;

namespace PetsAndOwners.Models
{
	public class AnimalModel: IBaseModel
	{
		public Guid AnimalPk { get; set; }

		public string Name { get; set; }

		public void PopulateData(object o)
		{
			var animal = (Animal)o;
			AnimalPk = animal.AnimalPk;
			Name = animal.Name;
		}
	}
}
