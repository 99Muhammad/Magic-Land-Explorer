using System;
using System.Collections.Generic;
using System.Linq;
using Magic_Land_Explorer_Lab;
using Newtonsoft.Json;

namespace MagicLandExplorer
{
    class Program
    {
        static void Main(string[] args)
        {
            clsCategory category = new clsCategory();
            clsMainScreen mainScreen = new clsMainScreen();
            do
            {
                clsMainScreen.MainScreen();
                clsMainScreen.ImplementUserChoise(mainScreen.ReadUserInput());

               
            } while (clsMainScreen.isExit== false);


        }
    }
}