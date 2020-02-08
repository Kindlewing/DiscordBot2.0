using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library.Factories;
using System;
using Unity;
using Unity.Injection;

namespace Library
{
	public static class Injector
	{
		private static IUnityContainer _container;

		public static IUnityContainer Container
		{
			get
			{
				if(_container == null)
					RegisterTypes();
				return _container;
			}
		}

		public static void RegisterTypes()
		{
			_container = new UnityContainer();

			_container.RegisterSingleton<Connection>();
			_container.RegisterSingleton<IDataStorage, DatabasesStorage>();
			_container.RegisterSingleton<DiscordSocketClient>
				(new InjectionConstructor(typeof(DiscordSocketConfig)));
			_container.RegisterSingleton<ILogger, Logger>();
			_container.RegisterSingleton<CommandService>();
			_container.RegisterSingleton<IServiceProvider>();

			_container.RegisterFactory<DiscordSocketConfig>
				(i => SocketConfigProvider.GetDefault());
			
		}

		public static T Resolve<T>()
		{
			return (T)Container.Resolve(typeof(T));
		}
	}
}
