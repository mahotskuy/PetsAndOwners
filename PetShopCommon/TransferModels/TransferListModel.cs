using System.Collections.Generic;

namespace PetShopCommon.TransferModels
{
	public class TransferListModel <T>
	{
		public int RowCount { get; set; }

		public List<T> Items { get; set; } 
	}
}
