using SeafClient;
using System;
using System.Threading.Tasks;

namespace SeafConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Test().Wait();

            Console.ReadKey();
        }

        static async Task Test()
        {
            try
            {
                var serverUri = new Uri("", UriKind.Absolute);
                var username = "";
                var password = "".ToCharArray();
                // authenticate with the Seafile server and retrieve a Session
                var session = await SeafSession.Establish(serverUri, username, password);
                var ping = await session.Ping();
                Console.WriteLine(session.ServerVersion);
                Console.WriteLine(ping);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
