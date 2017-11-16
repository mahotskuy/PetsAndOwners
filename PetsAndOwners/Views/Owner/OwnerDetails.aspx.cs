using System;
using System.Web.UI.WebControls;
using DBManager.Managers.Owner;
using Microsoft.Ajax.Utilities;
using PetsAndOwners.Models;

namespace PetsAndOwners.Views.Owner
{
	public partial class OwnerDetails : System.Web.UI.Page
	{
		public bool IsAddMode;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Guid ownerPk;
				if (Guid.TryParse(Request.QueryString["ownerPK"], out ownerPk))
				{
					var model = ClientModel.Create<OwnerModel>(OwnerDBManager.GetOwnerById(ownerPk));

					FirstName.Text = model.FirstName;
					LastName.Text = model.LastName;
					OwnerPK.Text = ownerPk.ToString();
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

		protected void AddOwner(object sender, EventArgs e)
		{
			if (ModelState.IsValid)
			{
				OwnerDBManager.AddOwner(GetOwnersData());
				RedirectToList();
			}
		}

		public void UpdateOwner(object sender, EventArgs e)
		{
			OwnerDBManager.UpdateOwner(GetOwnersData());
			RedirectToList();
		}

		private DBManager.DataConnection.Owner GetOwnersData()
		{
			return new DBManager.DataConnection.Owner
			{
				OwnerPK = OwnerPK.Text.IsNullOrWhiteSpace() ? Guid.NewGuid() : Guid.Parse(OwnerPK.Text),
				FirstName = FirstName.Text,
				LastName = LastName.Text
			};
		}

		private void RedirectToList()
		{
			Response.Redirect("OwnersList.aspx");
		}
	}
}