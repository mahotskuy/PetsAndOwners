namespace DBManager.DBManagerCommon
{
	public class TablesColumns
	{
		public static class DBO_Animal
		{
			public const string ANIMAL_PK = "AnimalPK";
			public const string NAME = "Name";
		}

		public static class DBO_Pet
		{
			public const string PET_PK = "PetPK";
			public const string NAME = "Name";
		}

		public static class DBO_Owner
		{
			public const string OWNER_PK = "OwnerPK";
			public const string FIRST_NAME = "FirstName";
			public const string LAST_NAME = "LastName";
		}
	}
}
