using Library;
using System.Threading.Tasks;

namespace UI
{
	class Program
	{
		static async Task Main()
		{
			Injector.RegisterTypes();
			Connection connection = Injector.Resolve<Connection>();
			await connection.ConnectAsync();
		}
	}
}
