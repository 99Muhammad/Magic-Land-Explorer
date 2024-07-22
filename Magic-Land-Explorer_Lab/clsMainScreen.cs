using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Land_Explorer_Lab
{
    public class clsMainScreen

    {
        public static bool  isExit { get; set; }
       
        public static Action<Action,string> ActionDelegate=DelegateImplementFunction ;

        public clsCategory category = new clsCategory();
        
        public static void DelegateImplementFunction(Action action,string AdressScreen)
        {
           
            Console.Clear();
            CreateDesignScreen(AdressScreen);
            //Calling the function 
            action();
            Console.WriteLine("Press any key to go back to main screen");
            Console.ReadKey();
            MainScreen();

        }
        static clsCategory Category = new clsCategory();
       
        public static void CreateDesignScreen(string ScreenAddress)
        {
            Console.WriteLine("\t\t----------------------------------------------\n");
            Console.WriteLine($"\t\t\t{ScreenAddress} Screen\n");
            Console.WriteLine("\t\t----------------------------------------------\n");
        }
        public int ReadUserInput()
        {
            int UserInput =0;
            int Input;
            while (true)

            {
                if(!int.TryParse((Console.ReadLine()), out Input))
                {
                    Console.WriteLine("\t\tYou entered invalid data ,try again :-(");
                }
               else if(Input < 1 || Input > 5)
                {
                    Console.WriteLine("\t\tThe value should be between 1 and 4, try again :-(");

                    
                }
                else
                {
                    break;
                }
               
            }
            UserInput = Input;
            return UserInput;
        }

        public static string YesOrNoAnswer( )
        {
           

            string Answer = "";
            while (true)
            {
                
                Answer = Console.ReadLine().ToLower();
                if (Answer == "yes" || Answer == "no")
                    return Answer;

            }
            return Answer;
        }
        public static void ImplementUserChoise(int UserInput)
        {

            switch(UserInput)
            {
                case 1:
                    {

                        DelegateImplementFunction(Category.GetDestinationNamesWithDurationLessThan100,
                            "Destinations with duration less than 100 minutes");
                        break;
                    }
                case 2:
                    {
                        DelegateImplementFunction(Category.GetDestinationNameWithLongestDuration,
                            "Destination with the longest duration");
                        break;
                    }
                case 3:
                    {
                        DelegateImplementFunction(Category.GetDestinationNamesAlphapitacally,
                            "Sorted destinations by name");
                        
                        break;
                    }
                case 4:
                    {
                        DelegateImplementFunction(Category.GetTop3LongestDuration,
                            "Top 3 longest-duration");
                        break;
                    }
                case 5:
                    {
                        Console.Write("\t\tAre you sure ?(yes / no )");
                        isExit = YesOrNoAnswer() == "yes";
                        break;
                    }

            }
        }
        public static void MainScreen()
        {
           
            Console.Clear();
            Console.WriteLine("\t\t----------------------------------------------\n");
            Console.WriteLine("\t\t\tMain Screen\n");
            Console.WriteLine("\t\t----------------------------------------------\n");

            Console.WriteLine("\t\tEnter a number from 1 to 4 ? ");

            Console.WriteLine("\t\t1- Do you want destinations with duration less than 100 minutes?");
            Console.WriteLine("\t\t2- Do you want destination with the longest duration?");
            Console.WriteLine("\t\t3- Do you want to Sorted destinations by name?");
            Console.WriteLine("\t\t4- Do you want top 3 longest-duration destinations?");
            Console.Write($"\t\t5-To exit from the programe?");


        }
    }
}
