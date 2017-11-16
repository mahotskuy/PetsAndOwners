using System;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;
using PetShopCommon;

namespace PetsAndOwners.Models
{
	public class OwnerModel : IBaseModel
	{
		
		//public string FullName => FirstName + LastName;

		[Key]
		public Guid OwnerPk { get; set; }

		[Display(ResourceType = typeof (TextResourse), Description = "txtFirstName")]
		[Required]
		[MinLength(3)]
		[MaxLength(50)]
		public string FirstName { get; set; }

		[Display(ResourceType = typeof(TextResourse), Description = "LastName")]
		[Required]
		[MinLength(3)]
		[MaxLength(50)]
		public string LastName { get; set; }

		#region impelemtation of IBaseModel

		public void PopulateData(object o)
		{
			var model = (DBManager.Models.Owner) o;

			OwnerPk = model.OwnerPk;
			FirstName = model.FirstName;
			LastName = model.LastName;
		}
		#endregion

	}
}