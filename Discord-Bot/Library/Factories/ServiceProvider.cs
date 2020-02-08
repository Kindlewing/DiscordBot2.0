using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Factories
{
	public static class ServiceProvider
	{
		public static IServiceProvider GetDefault()
		{
			IServiceCollection services = new ServiceCollection()
						.AddSingleton(Injector.Resolve<DiscordSocketClient>());

			return services.BuildServiceProvider();
		}
	}
}
