using Discord;
using System.Threading.Tasks;

namespace Library
{
	public interface ILogger
	{
		void Log(string message);
		Task DiscordLog(LogMessage message);
	}
}