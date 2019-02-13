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
        }

        static async Task Test()
        {
            try
            {
                var serverUri = new Uri("https://change_here", UriKind.Absolute);
                var username = "";
                var password = "".ToCharArray();
                // authenticate with the Seafile server and retrieve a Session
                var session = await SeafSession.Establish(serverUri, username, password);
                var t = await session.Ping();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
