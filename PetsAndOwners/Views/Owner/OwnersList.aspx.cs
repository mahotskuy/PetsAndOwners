using System;
using System.Web.UI.WebControls;
using DBManager.Managers.Owner;
using PetsAndOwners.Models;

namespace PetsAndOwners.Views.Owner
{
	public partial class OwnersList : System.Web.UI.Page
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
			TableBody.DataSource = ClientModel.CreateList<DBManager.Models.Owner, OwnerModel>(OwnerDBManager.GetOwnersByPage(0).Items);
			TableBody.DataBind();
		}

		protected void OnCreate(object sender, EventArgs e)
		{
			Response.Redirect("OwnerDetails.aspx?");
		}

		protected void DeleteOwner(object sender, CommandEventArgs e)
		{
			OwnerDBManager.DeleteOwnerById(Guid.Parse(e.CommandArgument.ToString()));
			PopulateGrid();
		}
	}
}