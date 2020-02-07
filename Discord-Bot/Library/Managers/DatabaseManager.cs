using System.Collections.Generic;
using System.Linq;

namespace Library
{
	public class DatabaseManager
	{
		private IDataStorage _storage;
		public DatabaseManager(IDataStorage storage)
		{
			_storage = storage;
		}

		public string GetToken()
		{
			List<string> token = _storage.RetrieveObject<string>("BotConfiguration", "Token");

			return token.FirstOrDefault();
		}
	}
}