using System;
using System.Web.UI.WebControls;
using DBManager.Managers.Animal;
using DBManager.Managers.Owner;
using PetsAndOwners.Models;

namespace PetsAndOwners.Views.Animal
{
	public partial class AnimalsList : System.Web.UI.Page
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
			AnimalList.DataSource = ClientModel.CreateList<DBManager.Models.Animal, AnimalModel>(AnimalDBManager.GetAllAnimals());
			AnimalList.DataBind();
		}

		protected void OnCreate(object sender, EventArgs e)
		{
			Response.Redirect("AnimalDetails.aspx?");
		}

		protected void OnDelete(object sender, CommandEventArgs e)
		{
			AnimalDBManager.DeleteAnimalById(Guid.Parse(e.CommandArgument.ToString()));
			PopulateGrid();
		}
	}
}