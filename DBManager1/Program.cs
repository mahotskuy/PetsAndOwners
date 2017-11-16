using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBManager.DataConnection;
using DBManager.Managers.Pet;
using DBManager.Models;

namespace DBManager
{
	class Program
	{
		public static void Main()
		{
			//var manager = new Owner();
			//var animals = manager.GetAllAnimals();
			//string s = "";

			//foreach (Animal animal in animals)
			//{
			//	s = string.Join("\n", s, $"{animal.AnimalPk} {animal.Name}");
			//}

			//Console.WriteLine(s);

			//Console.ReadLine();

			//List<DataConnection.Owner> owners;

			//using (var db = new PetsAndOwnersDataContext())
			//{
			//	db.Owners.InsertOnSubmit(new DataConnection.Owner
			//	{
			//		FirstName = "Jon",
			//		LastName = "Doe"
			//	});
			//	db.SubmitChanges();

			//	owners = db.Owners.ToList();
			//}

			//foreach (var owner in owners)
			//{
			//	Console.WriteLine($"{owner.OwnerPK} {owner.FirstName} {owner.LastName} \n");
			//}
			//Console.ReadLine();
		}
	}
}
