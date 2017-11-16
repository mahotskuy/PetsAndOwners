using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using PetShopCommon.TransferModels;

namespace PetsAndOwners.Models
{
	public class ClientModel
	{
		public static T Create<T>(object o) where T : IBaseModel, new()
		{
			var model = new T();
			model.PopulateData(o);
			return model;
		}

		public static List<TResult> CreateList<TSource, TResult>(List<TSource> lo) where TResult : IBaseModel, new()
		{
			return lo.Select(
				entity =>
				{
					var model = new TResult();
					model.PopulateData(entity);
					return model;
				}).ToList();
		}
	}
}