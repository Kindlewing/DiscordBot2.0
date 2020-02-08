using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Library.Managers
{
	public class CommandManager
	{
		private readonly CommandService _commandService;
		private readonly DiscordSocketClient _client;
		private readonly IServiceProvider _serviceProvider;
		private readonly DatabaseManager _databaseManager;
		public CommandManager(CommandService commandService,
							  DiscordSocketClient client,
							  IServiceProvider serviceProvider, 
							  DatabaseManager databaseManager)
		{
			_commandService = commandService;
			_client = client;
			_serviceProvider = serviceProvider;
			_databaseManager = databaseManager;
		}

		public async Task InitializeAsync()
		{
			await _commandService.AddModulesAsync(Assembly.GetEntryAssembly(),
				services: _serviceProvider);

		}

		private async Task ManageCommandsAsync(SocketMessage message)
		{
			var msg = message as SocketUserMessage;

			if (msg == null) { return; }

			var context = new SocketCommandContext(_client, msg);

			int argPos = 0;

			if (msg.HasStringPrefix(_databaseManager.GetCommandPrefix(), ref argPos))
			{
				var result = await _commandService.ExecuteAsync
					(context, argPos, services: null);

				if (!result.IsSuccess && result.Error
					!= CommandError.UnknownCommand)
				{
					System.Console.WriteLine(result.ErrorReason);
				}
			}
		}
	}
}
