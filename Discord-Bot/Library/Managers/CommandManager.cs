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

		public CommandManager(CommandService commandService,
			DiscordSocketClient client, IServiceProvider serviceProvider)
		{
			_commandService = commandService;
			_client = client;
			_serviceProvider = serviceProvider;
		}

		public async Task InitializeAsync()
		{
			await _commandService.AddModulesAsync(Assembly.GetEntryAssembly(),
				services: _serviceProvider);
		}
	}
}
