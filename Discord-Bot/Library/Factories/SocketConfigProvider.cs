using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Factories
{
	public static class SocketConfigProvider
	{
		public static DiscordSocketConfig GetDefault()
		{
			return new DiscordSocketConfig()
			{
				LogLevel = Discord.LogSeverity.Verbose
			};
		}

	}
}
