using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static string defaultDataPath = @"c:\data\";
        static string dataPath;
        static bool passwordCheck = true;
        static string userInput;
        static bool nameCheck = true;
        static bool skipLogReg = false;
        static string passwordInput;

        static void Main(string[] args)
        {
            bool run = true;
            bool programRun = true;

            while (programRun == true)
            {

                var user = new User();
                user.Name = "";
                user.Password = "";
                user.Balance = 0;

                while (skipLogReg == false)
                {
                    Console.WriteLine("Login or Register?");
                    userInput = Console.ReadLine();

                    if (userInput == "Login")
                    {
                        User.Login(user, defaultDataPath, dataPath, passwordInput, nameCheck, passwordCheck, skipLogReg);
                        if (passwordInput == user.Password)
                        {
                            skipLogReg = true;
                        }
                    }
                    else if (userInput == "Register")
                    {
                        User.Register(user, defaultDataPath, dataPath, userInput, nameCheck, passwordCheck);
                    }
                }

                while (run == true)
                {
                    Console.WriteLine("What do you wish to do? (Insert/Withdraw) Write 'STOP' if you are done");
                    userInput = Console.ReadLine();

                    if (userInput == "Insert")
                    {
                        user.Insert();
                    }
                    else if (userInput == "Withdraw")
                    {
                        user.Withdraw();
                    }
                    else if (userInput == "STOP")
                    {
                        run = false;
                    }
                }
            }
        }
    }
}
