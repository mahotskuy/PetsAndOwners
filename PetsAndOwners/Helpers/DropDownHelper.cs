using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.Owin.Security.OAuth;
using PetsAndOwners.Models.Common;

namespace PetsAndOwners.Helpers
{
	public class DropDownHelper
	{
		private const string DataTextField = "Value";
		private const string DataValueField = "ItemPK";

		public static void SetDataToDropDown<T>(DropDownList dropdown, List<DropDownModel<T>> dataSource, Guid selectedPK)
		{
			SetDataSource<T>(dropdown, dataSource);
			SetSelectedItem<T>(dropdown, selectedPK);
		}

		public static void SetDataSource<T>(DropDownList dropdown, List<DropDownModel<T>> dataSource)
		{
			dropdown.DataTextField = DataTextField;
			dropdown.DataValueField = DataValueField;
			dropdown.DataSource = dataSource;
		}

		public static void SetSelectedItem<T>(DropDownList dropdown, Guid? selectedPk)
		{
			int itemIndex = ((List<DropDownModel<T>>)dropdown.DataSource).FindIndex(i => i.ItemPk.Equals(selectedPk));
			dropdown.SelectedIndex = itemIndex == -1 ? 0 : itemIndex;
		}
	}
}