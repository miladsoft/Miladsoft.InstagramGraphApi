/*
 * Developer: Milad Raeisi [ miladsoft@yahoo.com ] [ My Telegram Account: https://t.me/miladsoft ]
 * 
 * Github source: https://github.com/miladsoft/InstagramGraphApi
 * Nuget package: https://www.nuget.org/packages/Miladsoft.InstagramGraphApi/
 * 
 */
using System;
using System.Web;
using InstagramGraphApi.API;
using InstagramGraphApi.API.Builder;
using InstagramGraphApi.Classes;

namespace ConsoleApp.Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Start of process in {DateTime.Now}.....");

            Execute();

            Console.WriteLine($"\nEnd of process in {DateTime.Now}.....");
            Console.WriteLine("\n\n");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }


        private static IInstagramGraphApi _InstagramGraphApi;
        private static void Execute()
        {
            _InstagramGraphApi = InstagramGraphApiBuilder.CreateBuilder()
                                                            .SetUser(new UserSessionData { Username = "Username", Password = "*******" })
                                                            .Build();

            TestClass testClass = new TestClass(_InstagramGraphApi);

            var IsAuthenticated = testClass.ExecuteLoginTest();

            if (!IsAuthenticated)
            {
                return;
            }
            //for example : 
            var userDetails = testClass.GetUserDetailsTest("milad._.raeisi");

            Console.WriteLine("=================================");
        }
    }
}
