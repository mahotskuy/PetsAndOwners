using System.Security.Cryptography.X509Certificates;

namespace PetsAndOwners.Models
{
	public interface IBaseModel
	{
		/// <summary>
		/// Use to implement method for populating client side model from server side model.
		/// </summary>
		/// <param name="o"></param>
		void PopulateData(object o);
	}
}