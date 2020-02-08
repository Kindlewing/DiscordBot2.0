using System.Collections.Generic;
using System.Linq;

namespace Library
{
	public class DatabaseManager
	{
		private readonly IDataStorage _storage;
		public DatabaseManager(IDataStorage storage)
		{
			_storage = storage;
		}

		public string GetToken()
		{
			List<string> token = _storage.RetrieveObject<string>("BotConfiguration", "Token");
			return token.FirstOrDefault();
		}

		public string GetCommandPrefix()
		{
			List<string> commandPrefix = _storage.RetrieveObject<string>
				("BotConfiguration", "CommandPrefix");
			return commandPrefix.FirstOrDefault();

		}
	}
}