using ConsoleApp1;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection.Emit;
using System.Threading;

namespace ConsoleApp1
{
    class GameTime
    {
        public struct Date
        {
            public string toString
            {
                get
                {
                    string s = "s";
                    return String.Format("{0} Day{3} {1} Hour{4} {2} Quarter{5}", day, hour, quarter, day > 1 ? s : "", hour > 1 ? s : "", quarter > 1 ? s : "");
                }
            }
        }
        static int _hour;
        static int _quarter;

        public static int quarterTick { get { return ((day * 24) + hour) * 4; } }
        public static int day { get; set; }
        public static int hour { get { return _hour; } set { day = value / 24; _hour = value % 24; } }
        public static int quarter { get { return _quarter; } set { hour += value / 4; _quarter = value % 4; } }

        public static Date date { get; }

        public static void Init()
        {
            SetTime(0, 14, 0);
        }

        public static void SetTime(int day, int hour, int quarter)
        {
            GameTime.day = day;
            GameTime.hour = hour;
            GameTime.quarter = quarter;
        }
    }
    class Location
    {
        public int index;
        public string name;
        public bool haveBeen = false;
        public Location(int index, string name, bool haveBeen = false)
        {
            this.index = index;
            this.name = name;
            this.haveBeen = haveBeen;
        }
    }
    class LocationManager
    {
        public static Location WestBeach = new Location(0, "WestBeach");
        public static Location WestCoast = new Location(1, "WestCoast");
        public static Location WestJungle = new Location(2, "WestJungle");
    }

    class Program
    {
        //Debug Variable
        static string input;
        static void Main(string[] args)
        {
            Location locationNow = LocationManager.WestBeach;
        StartMenu:
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1) Start A New Game");
            Console.WriteLine("2) Load Game");
            Console.WriteLine("3) End Game");
            switch (Console.ReadLine())
            {
                case null:
                    goto StartMenu;
                case "1":
                    Console.Clear();
                    Console.WriteLine("Game Start!");
                    Console.ReadLine();
                    goto NewGameStart;
                case "2":


                case "3":
                    goto End;

                case "Debug":
                    //Debug Zone
                    {
                    }
                    goto StartMenu;




                default:
                    Console.WriteLine("Sorry, I don't understand");
                    goto StartMenu;
            }
        NewGameStart:
            Console.Clear();
            Console.WriteLine("It's a great vocation morning. You have planned to travel to fiji since half years ago.");
            Console.WriteLine("But on the mid of plane flying, it crush on a island.");
            Console.WriteLine("When you wake up, you feel no injure anywhere, it's wierd, and nobody around you. Is it a dream?");
            Console.WriteLine("But, most importantly, You feel a little bit of hungry right now.");
            goto Movements;






        Movements:
            Console.WriteLine();
            Console.WriteLine("What's Next To Do?");
            Console.WriteLine("1) Check Bag");
            Console.WriteLine("2) Look Around");
            switch (Console.ReadLine())
            {
                case "1":
                    goto CheckBag;
                case "2":
                    goto LookAround;
                default:
                    break;
            }
        CheckBag:
            Console.Clear();
            Console.WriteLine("There is nothing inside.");
            Console.ReadLine();            
            goto Movements;
        LookAround:
            Console.Clear();
            switch (locationNow.name)
            {
                case "WestBeach":
                    {
                        if (!LocationManager.WestBeach.haveBeen)
                        {
                            Console.WriteLine("You are now on the beach.");
                            Console.WriteLine("It's a beautiful tropic island.");
                            Console.WriteLine("The ocean is bule, the jungle is primitive and dense.");
                            Console.WriteLine("Sun is at the ocean side, means you're on the west of this island.");
                            Console.WriteLine("By observing the solar elevation. It looks like it's afternoon now.");
                            LocationManager.WestBeach.haveBeen = true;
                        }
                        else
                        {
                            Console.WriteLine("You are now on the west beach.");
                        }
                        Console.WriteLine();
                        Console.WriteLine("What do you want to do?");
                        Console.WriteLine("1) Close to the coast.");
                        Console.WriteLine("2) Go to the jungle.");
                        Console.WriteLine("3) Walk to north along the beach");
                        Console.WriteLine("4) Do nothing.");
                        input = Console.ReadLine();
                        Console.Clear();
                        switch (input)
                        {
                            case "1":
                                GameTime.quarter += 1;
                                Console.WriteLine("You took 15 minute.");
                                locationNow = LocationManager.WestCoast;
                                break;
                            case "2":
                                GameTime.quarter += 2;
                                Console.WriteLine("You took 30 minute.");
                                locationNow = LocationManager.WestJungle;
                                break;
                            default:
                                goto LookAround;
                        }
                        Console.ReadLine();
                        break;
                    }
                case "WestCoast":
                    {
                        if (!LocationManager.WestJungle.haveBeen)
                        {
                            //First Time
                            Console.WriteLine("You are now at west coast. First time.");
                        }
                        else
                        {
                            Console.WriteLine("You are now at west coast.");
                        }
                        Console.WriteLine("What do you want to do?");
                        Console.WriteLine("1) Go to the Beach.");
                        Console.WriteLine("2) Walk north along the cost.");
                        Console.WriteLine("3) Walk south along the cost.");
                        input = Console.ReadLine();
                        Console.Clear();
                        switch (input)
                        {
                            case "1":
                                GameTime.quarter += 1;
                                Console.WriteLine("You took 15 minute.");
                                locationNow = LocationManager.WestBeach;
                                break;
                            default:
                                goto LookAround;
                        }
                        break;

                    }
                case "WestJungle":
                    {
                        break;
                    }
            }
            goto LookAround;

        LoadGame:

        End:
            Console.Clear();
            Console.WriteLine("Thanks for your playing!");
            Console.ReadLine();
        }
    }


}
