using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DBManager.DBManagerCommon
{
    class DBManagerHelper
    {
	    private const string CONNECTION_STRING_NAME = "PetShopConnectionString";

	    public static string ConnectionString
	    {
		    get
		    {
			    return ConfigurationManager.ConnectionStrings[CONNECTION_STRING_NAME].ConnectionString;
			}
	    }

		/// <summary>
		/// Creates the parameter.
		/// </summary>
		/// <param name="parameterName">Name of the parameter.</param>
		/// <param name="value">The value.</param>
		/// <param name="type">The type.</param>
		/// <returns>Data parameter to be passed to the stored procedure.</returns>
		public static IDataParameter CreateParameter(string parameterName, object value, DbType type)
		{
			return new SqlParameter
			{
				ParameterName = parameterName,
				DbType = type,
				Direction = ParameterDirection.Input,
				Value = value
			};
		}

		/// <summary>
		/// Calculates and creates start row parameter based on page index
		/// </summary>
		/// <param name="parameterName">Name of the start row parameter</param>
		/// <param name="pageIndex">Index of the page to be retrieved</param>
		/// <param name="rowCount">Number of the rows per page</param>
		/// <returns></returns>
		public static IDataParameter CreateStartRowIndexParameter(string parameterName, int pageIndex, int rowCount)
		{
			int startRowIndex = pageIndex * rowCount + 1;

			return CreateParameter(parameterName, startRowIndex, DbType.Int32);
		}

		/// <summary>
		/// Calculates and creates end row parameter based on page index
		/// </summary>
		/// <param name="parameterName">Name of the end row parameter</param>
		/// <param name="pageIndex">Index of the page to be retrieved</param>
		/// <param name="rowCount">Number of the rows per page</param>
		/// <returns></returns>
		public static IDataParameter CreateEndRowIndexParameter(string parameterName, int pageIndex, int rowCount)
		{
			int endRowIndex = pageIndex * rowCount + rowCount;

			return CreateParameter(parameterName, endRowIndex, DbType.Int32);
		}

	    public static IDataReader ExecuteReader(string cmdText, IDataParameter[] dbParameters, CommandType commandType = CommandType.StoredProcedure)
	    {
		    SqlConnection connection = new SqlConnection(ConnectionString);
			SqlCommand command = new SqlCommand(cmdText, connection)
			{
				CommandType = commandType
			};

		    if (dbParameters != null)
		    {
			    command.Parameters.AddRange(dbParameters);
		    }

			connection.Open();

		    return command.ExecuteReader();
	    }

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <typeparam name="T">Type of object to return</typeparam>
		/// <param name="reader">The reader.</param>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>Value with type T</returns>
		public static T GetValue<T>(IDataReader reader, string columnName)
		{
			return (T)reader[columnName];
		}
	}
}
