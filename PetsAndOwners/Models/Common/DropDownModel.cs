using System;
using DBManager.Models.Common;

namespace PetsAndOwners.Models.Common
{
	public class DropDownModel<T> : IBaseModel
	{
		public T ItemPk { get; set; }

		public string Value { get; set; }

		public void PopulateData(object o)
		{
			var model = (DropDown<T>) o;

			ItemPk = model.ItemPk;
			Value = model.Value;
		}
	}
}
