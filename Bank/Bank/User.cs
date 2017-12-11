using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class User
    {
        public string Name;
        public string Password;
        public int Balance;

        static bool breakout = false;

        int userInput;

        //Register function
        public static void Register(User user, string defaultDataPath, string dataPath, string userInput, bool nameCheck, bool passwordCheck)
        {
            Console.WriteLine("Choose your username: ");
            user.Name = Console.ReadLine();
            dataPath = defaultDataPath + user.Name + ".txt";
            if (File.Exists(dataPath))
            {
                while (nameCheck == true)
                {
                    Console.WriteLine("Username already exists, please try again(Type 'Back' if you want to cancel current action): ");
                    user.Name = Console.ReadLine();
                    dataPath = defaultDataPath + user.Name + ".txt";
                    if (!File.Exists(dataPath))
                    {
                        nameCheck = false;
                    }
                    if (user.Name == "Back")
                    {
                        breakout = true;
                    }
                }
            }

            //If user wrote "back" then program goes back to choosing between login and register
            if (breakout == false)
            {
                Console.WriteLine("Choose your password: ");
                user.Password = Console.ReadLine();
                while (passwordCheck == true)
                {
                    Console.WriteLine("Repeat password(Type 'Back' if you want to cancel current action): ");
                    userInput = Console.ReadLine();
                    if (userInput == "Back")
                    {
                        breakout = true;
                        passwordCheck = false;
                    }

                    if (breakout == false)
                    {
                        if (userInput == user.Password)
                        {
                            if (!File.Exists(dataPath))
                            {
                                using (StreamWriter sw = File.CreateText(dataPath))
                                {
                                    sw.WriteLine(user.Password);
                                    sw.WriteLine(user.Balance);
                                    passwordCheck = false;
                                }
                            }
                        }
                    }
                    breakout = false;
                }
            }
        }

        //Login function
        //public static void Login(User user, string defaultDataPath, string dataPath, string passwordInput, bool nameCheck, bool passwordCheck, bool skipLogReg)
        //{
        //    nameCheck = true;
        //    Console.WriteLine("Please insert your username: ");
        //    user.Name = Console.ReadLine();
        //    dataPath = defaultDataPath + user.Name + ".txt";

        //    if (!File.Exists(dataPath))
        //    {
        //        while (nameCheck == true)
        //        {
        //            Console.WriteLine("Username doesn't exist, please try again(Type 'Back' if you want to cancel current action): ");
        //            user.Name = Console.ReadLine();
        //            dataPath = defaultDataPath + user.Name + ".txt";
        //            if (File.Exists(dataPath))
        //            {
        //                nameCheck = false;
        //            }
        //            if (user.Name == "Back")
        //            {
        //                breakout = true;
        //            }
        //        }
        //    }

        //    if (breakout == false)
        //    {
        //        if (File.Exists(dataPath))
        //        {
        //            using (StreamReader sr = File.OpenText(dataPath))
        //            {
        //                user.Password = sr.ReadLine();
        //                user.Balance = Int32.Parse(sr.ReadLine());
        //            }

        //            Console.WriteLine("Please insert your password: ");
        //            passwordInput = Console.ReadLine();
        //            if (passwordInput != user.Password)
        //            {
        //                while (passwordCheck == true)
        //                {
        //                    Console.WriteLine("Password isn't correct, try again(Type 'Back' if you want to cancel current action)");
        //                    passwordInput = Console.ReadLine();
        //                    if (passwordInput == user.Password)
        //                    {
        //                        passwordCheck = false;
        //                        skipLogReg = true;
        //                    }
        //                    if (passwordInput == "Back")
        //                    {
        //                        breakout = true;
        //                    }
        //                }

        //            }
        //        }
        //    }
        //}

        //Insert function
        public void Insert()
        {
            Console.WriteLine("How much money do you want to insert?");
            userInput = Int32.Parse(Console.ReadLine());
            Balance = Balance + userInput;
            Console.WriteLine("Your new balance is: " + Balance);
        }

        //Withdraw function
        public void Withdraw()
        {
            Console.WriteLine("How much money do you want to withdraw?");
            userInput = Int32.Parse(Console.ReadLine());
            Balance = Balance - userInput;
            Console.WriteLine("Your new balance is: " + Balance);
        }
    }
}
