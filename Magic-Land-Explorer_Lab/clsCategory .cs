using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Magic_Land_Explorer_Lab
{
    public class clsCategory
    {
        List<clsCategory> categories;

        int GetDurationInMinutes(string durationString)
        {
            string[] v = durationString.Split(" ");
            return Convert.ToInt32(v[0]);
        }
        public void GetDestinationNamesWithDurationLessThan100()
        {
            int Count = 0;
            categories = ReadDataFromJson();

            var lessThan100Minutes = categories.SelectMany(e => e.destinations).ToList();

            var less = lessThan100Minutes.Where(e => GetDurationInMinutes(e.Duration ?? "10") < 100);

            foreach (var item in less)
            {
                Console.WriteLine($"{++Count}) { item.Name}");
            }
        }
        public void GetDestinationNameWithLongestDuration()
        {
            categories = ReadDataFromJson();
            var orderedDestinations = categories.SelectMany(e => e.destinations)
                .OrderByDescending(d => GetDurationInMinutes(d.Duration??"10"))
                .ThenBy(d => d.Name)
                .Take(1)
                .ToList();

            for (int x = 0; x < orderedDestinations.Count; x++)
            {
                Console.WriteLine($"Destination: {orderedDestinations[x].Name}");
            }
        }

        public void GetDestinationNamesAlphapitacally()
        {

            categories = ReadDataFromJson();
            var orderedDestinations = categories.SelectMany(e => e.destinations)
                  .OrderBy(d => d.Name)
                 
                  .ToList();

            for (int x = 0; x < orderedDestinations.Count; x++)
            {
                Console.WriteLine($"Destination: {orderedDestinations[x].Name}");
            }
          
        }
        public void GetTop3LongestDuration()
        {
            int Count = 0;
            categories = ReadDataFromJson();
            var orderedDestinations = categories.SelectMany(e => e.destinations)
                .OrderByDescending(d => GetDurationInMinutes(d.Duration??"10"))
                .ThenBy(d => d.Name)
                .Take(3)
                .ToList();

            for (int x = 0; x < orderedDestinations.Count; x++)
            {
                Console.WriteLine($"{++Count})Destination: {orderedDestinations[x].Name}," +
                    $" Duration: {orderedDestinations[x].Duration}");
         
        }
        }
        public string category { get; set; }
        public  List<clsDestination> destinations { get; set; }
        
        public List<clsCategory> ReadDataFromJson()
        {
            string jsonPath = @"C:\Users\Student\source\repos\Magic-Land-Explorer\Magic-Land-Explorer_Lab\Data\jsconfig1.json";

            var data = File.ReadAllText(jsonPath);

            List<clsCategory> categories = JsonConvert.DeserializeObject<List<clsCategory>>(data);
            return categories;
        }
       
     
        }
   
}