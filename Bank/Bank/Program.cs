using System;
using System.IO;
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
        static string userInput;
        static string passwordInput;

        static bool nameCheck = true;
        static bool passwordCheck = true;
        static bool skipLogReg = false;

        static bool breakout = false;

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
                        //User.Login(user, defaultDataPath, dataPath, passwordInput, nameCheck, passwordCheck, skipLogReg);

                        nameCheck = true;
                        Console.WriteLine("Please insert your username: ");
                        user.Name = Console.ReadLine();
                        dataPath = defaultDataPath + user.Name + ".txt";

                        if (!File.Exists(dataPath))
                        {
                            while (nameCheck == true)
                            {
                                Console.WriteLine("Username doesn't exist, please try again(Type 'Back' if you want to cancel current action): ");
                                user.Name = Console.ReadLine();
                                dataPath = defaultDataPath + user.Name + ".txt";
                                if (File.Exists(dataPath))
                                {
                                    nameCheck = false;
                                }
                                if (user.Name == "Back")
                                {
                                    breakout = true;
                                }
                            }
                        }

                        if (breakout == false)
                        {
                            if (File.Exists(dataPath))
                            {
                                using (StreamReader sr = File.OpenText(dataPath))
                                {
                                    user.Password = sr.ReadLine();
                                    user.Balance = Int32.Parse(sr.ReadLine());
                                }

                                Console.WriteLine("Please insert your password: ");
                                passwordInput = Console.ReadLine();
                                if (passwordInput != user.Password)
                                {
                                    while (passwordCheck == true)
                                    {
                                        Console.WriteLine("Password isn't correct, try again(Type 'Back' if you want to cancel current action)");
                                        passwordInput = Console.ReadLine();
                                        if (passwordInput == user.Password)
                                        {
                                            passwordCheck = false;
                                        }
                                        if (passwordInput == "Back")
                                        {
                                            breakout = true;
                                        }
                                    }
                                }
                                if (passwordInput == user.Password)
                                {
                                    skipLogReg = true;
                                }
                            }
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
