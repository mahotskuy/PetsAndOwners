using System;
using DBManager.Managers.Animal;
using DBManager.Managers.Owner;
using DBManager.Managers.Pet;
using DBManager.Models.Common;
using Microsoft.Ajax.Utilities;
using PetsAndOwners.Helpers;
using PetsAndOwners.Models;
using PetsAndOwners.Models.Common;
using PetShopCommon;

namespace PetsAndOwners.Views.Pet
{
	public partial class PetDetails : System.Web.UI.Page
	{
		public bool IsAddMode { get; set; }

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				DropDownHelper.SetDataSource(PetType, ClientModel.CreateList<DropDown<Guid>, DropDownModel<Guid>>(AnimalDBManager.GetAnimalsDropDown()));

				var ownerDropDown = ClientModel.CreateList<DropDown<Guid?>, DropDownModel<Guid?>>(OwnerDBManager.GetOwnersDropDown());
				ownerDropDown.Insert(0, new DropDownModel<Guid?>
				{
					ItemPk = null,
					Value = TextResourse.txtNotSpecified
				});

				DropDownHelper.SetDataSource(PetOwner, ownerDropDown);

				Guid petPk;
				if (Guid.TryParse(Request.QueryString["petPK"], out petPk))
				{
					var model = ClientModel.Create<PetModel>(PetDBManager.GetOwnerById(petPk));

					PetPkField.Text = model.PetPk.ToString();
					PetName.Text = model.PetName;

					DropDownHelper.SetSelectedItem<Guid>(PetType, model.AnimalPk);

					DropDownHelper.SetSelectedItem<Guid?>(PetOwner, model.OwnerPk);
				}
				else
				{
					IsAddMode = true;
				};

				DataBind();
			}
		}

		public void OnUpdate(object sender, EventArgs e)
		{
			PetDBManager.UpdatePet(GetPetData());
			RedirectToList();
		}

		protected void OnSave(object sender, EventArgs e)
		{
				PetDBManager.AddPet(GetPetData());
				RedirectToList();
		}

		private DBManager.DataConnection.Pet GetPetData()
		{
			return new DBManager.DataConnection.Pet
			{
				PetPK = PetPkField.Text.IsNullOrWhiteSpace() ? Guid.NewGuid() : Guid.Parse(PetPkField.Text),
				Name = PetName.Text,
				OwnerPK = PetOwner.SelectedValue.IsNullOrWhiteSpace() ? null : (Guid?)Guid.Parse(PetOwner.SelectedValue),
				AnimalPK = Guid.Parse(PetType.SelectedValue),
			};
		}

		protected void OnCancel(object sender, EventArgs e)
		{
			RedirectToList();
		}

		private void RedirectToList()
		{
			Response.Redirect("PetsList.aspx");
		}
	}
}