using System;
using System.Web.UI.WebControls;
using DBManager.Managers.Pet;
using PetsAndOwners.Models;

namespace PetsAndOwners.Views.Pet
{
	public partial class PetsList : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				PopulateGrid();
			}
		}

		public void PopulateGrid()
		{
			TableBody.DataSource = ClientModel.CreateList<DBManager.Models.Pet, PetModel>(PetDBManager.GetPetList());
			TableBody.DataBind();
		}

		protected void OnCreate(object sender, EventArgs e)
		{
			Response.Redirect("PetDetails.aspx?");
		}

		protected void Delete(object sender, CommandEventArgs e)
		{
			PetDBManager.DeletePetById(Guid.Parse(e.CommandArgument.ToString()));
			PopulateGrid();
		}
	}
}