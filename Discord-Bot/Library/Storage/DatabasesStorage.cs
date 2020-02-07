using System;
using Dapper;
using System.Configuration;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace Library
{
	public class DatabasesStorage : IDataStorage
	{
		public void StoreObject(string location, string key)
		{
			throw new NotImplementedException();
		}

		public List<T> RetrieveObject<T>(string location, string key)
		{
			using(IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
			{ 
				var output = connection.Query<T>
					($"select {key} from {location}", new DynamicParameters());
				return output.ToList();
			}
		}

		private string LoadConnectionString()
		{
			return "Data Source =.\\DiscordDatabase.db";    
		}
	}
}
