using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace Library
{
	public class Connection
	{
		private readonly DiscordSocketClient _client;
		private readonly DatabaseManager _databaseManager;
		private readonly ILogger _logger;
		public Connection(DiscordSocketClient client, DatabaseManager databaseManager,
						 ILogger logger)
		{
			_client = client;
			_databaseManager = databaseManager;
			_logger = logger;
		}

		public async Task ConnectAsync()
		{
			if(_databaseManager.GetToken() == "" || _databaseManager.GetToken() == null)
				return;

			_client.Log += _logger.DiscordLog;

			await _client.LoginAsync(TokenType.Bot, _databaseManager.GetToken());
			await _client.StartAsync();

			await Task.Delay(-1); 
		}
	}
}
