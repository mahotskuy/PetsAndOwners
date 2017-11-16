using System;
using DBManager.Managers.Animal;
using Microsoft.Ajax.Utilities;
using PetsAndOwners.Models;

namespace PetsAndOwners.Views.Animal
{
	public partial class AnimalDetails : System.Web.UI.Page
	{
		public bool IsAddMode { get; set; }

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Guid detailsPk;

				if (Guid.TryParse(Request.QueryString["detailsPK"], out detailsPk))
				{
					var model = ClientModel.Create<AnimalModel>(AnimalDBManager.GetAnimalById(detailsPk));

					Name.Text = model.Name;

					ItemPK.Text = detailsPk.ToString();
				}
				else
				{
					IsAddMode = true;
				};

				DataBind();
			}
		}

		protected void OnCancel(object sender, EventArgs e)
		{
			RedirectToList();
		}

		protected void OnSave(object sender, EventArgs e)
		{
			AnimalDBManager.AddAnimal(GetDetailsData());
			RedirectToList();
		}

		public void OnUpdate(object sender, EventArgs e)
		{
			AnimalDBManager.UpdateAnimal(GetDetailsData());
			RedirectToList();
		}

		private DBManager.DataConnection.Animal GetDetailsData()
		{
			return new DBManager.DataConnection.Animal
			{
				AnimalPK = ItemPK.Text.IsNullOrWhiteSpace() ? Guid.NewGuid() : Guid.Parse(ItemPK.Text),
				Name = Name.Text
			};
		}

		private void RedirectToList()
		{
			Response.Redirect("AnimalList.aspx");
		}
	}
}