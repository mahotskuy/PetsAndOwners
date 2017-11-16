using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using DBManager.DataConnection;
using DBManager.DBManagerCommon;
using PetShopCommon;
using PetShopCommon.Enums;
using PetShopCommon.TransferModels;

namespace DBManager.Managers.Owner
{
	public static class OwnerDBManager
	{
		public static TransferListModel<Models.Owner> GetOwnersByPage(
			int pageIndex)
		{
			List<Models.Owner> owners = new List<Models.Owner>();
			int rowCount = 0;

			var parameters = new[]
			{
				DBManagerHelper.CreateStartRowIndexParameter("startRowIndex", pageIndex, (int) PageSizes.Standart),
				DBManagerHelper.CreateEndRowIndexParameter("endRowIndex", pageIndex, (int) PageSizes.Standart)
			};
			using (var reader = DBManagerHelper.ExecuteReader(StoreProcedureNames.DBO_OWNERS_GET_BY_PAGE, parameters))
			{
				while (reader.Read())
				{
					owners.Add(new Models.Owner
					{
						OwnerPk = DBManagerHelper.GetValue<Guid>(reader, TablesColumns.DBO_Owner.OWNER_PK),
						FirstName = DBManagerHelper.GetValue<string>(reader, TablesColumns.DBO_Owner.FIRST_NAME),
						LastName = DBManagerHelper.GetValue<string>(reader, TablesColumns.DBO_Owner.LAST_NAME),
					});

					if (rowCount == 0)
					{
						rowCount = DBManagerHelper.GetValue<int>(reader, Costants.RowCountText);
					}
				}
			}

			return new TransferListModel<Models.Owner>
			{
				RowCount = rowCount,
				Items = owners
			};
		}

		public static Models.Owner GetOwnerById(Guid ownerPK)
		{
			var owner = new PetsAndOwnersDataContext().Owners.FirstOrDefault(o => o.OwnerPK.Equals(ownerPK)) ??
			            new DataConnection.Owner();
			return new Models.Owner
			{
				OwnerPk = owner.OwnerPK,
				FirstName = owner.FirstName,
				LastName = owner.LastName,
			};
		}

		public static void DeleteOwnerById(Guid ownerPK)
		{
			using (var context = new PetsAndOwnersDataContext())
			{
				var owner = context.Owners.FirstOrDefault(o => o.OwnerPK == ownerPK);
				if(owner !=null)
				context.Owners.DeleteOnSubmit(owner);
				context.SubmitChanges();
			}
		}

		public static void AddOwner(DataConnection.Owner owner)
		{
			using (var context = new PetsAndOwnersDataContext())
			{
				context.Owners.InsertOnSubmit(owner);
				context.SubmitChanges();
			}
		}

		public static void UpdateOwner(DataConnection.Owner owner)
		{
			using (var context = new PetsAndOwnersDataContext())
			{
				var dbOwner = context.Owners.First(o => o.OwnerPK == owner.OwnerPK);
				dbOwner.FirstName = owner.FirstName;
				dbOwner.LastName = owner.LastName;
				context.SubmitChanges();
			}
		}

		public static List<Models.Common.DropDown<Guid?>> GetOwnersDropDown()
		{
			using (var context = new PetsAndOwnersDataContext(DBManagerHelper.ConnectionString))
			{
				return context.Owners.Select(o => new Models.Common.DropDown<Guid?>
				{
					ItemPk = o.OwnerPK,
					Value = $"{o.FirstName} {o.LastName}"
				}).ToList();
			}
		}
	}
}
