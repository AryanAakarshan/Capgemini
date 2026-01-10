using System;
using System.Collections.Generic;
using System.Linq;

namespace DialingCodesApp
{
    public static class DialingCodes
    {
        // Task 1: Empty Dictionary
        public static Dictionary<int, string> GetEmptyDictionary()
        {
            return new Dictionary<int, string>();
        }

        // Task 2: Predefined Dictionary
        public static Dictionary<int, string> GetExistingDictionary()
        {
            return new Dictionary<int, string>
            {
                { 1, "United States of America" },
                { 55, "Brazil" },
                { 91, "India" }
            };
        }

        // Task 3: Add country to empty dictionary
        public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
        {
            Dictionary<int, string> dialingCode = new Dictionary<int, string>();
            dialingCode.Add(countryCode, countryName);
            return dialingCode;
        }

        // Task 4: Add country to existing dictionary
        public static void AddCountryToExistingDictionary(
            Dictionary<int, string> existingDict,
            int countryCode,
            string countryName)
        {
            existingDict[countryCode] = countryName;
        }

        // Task 5: Retrieve country name
        public static string GetCountryNameFromDictionary(
            Dictionary<int, string> existingDict,
            int countryCode)
        {
            return existingDict[countryCode];
        }

        // Task 7: Update existing country name
        public static void UpdateDictionary(
            Dictionary<int, string> existingDict,
            int countryCode,
            string updatedCountryName)
        {
            if (existingDict.ContainsKey(countryCode))
            {
                existingDict[countryCode] = updatedCountryName;
            }
        }

        // Task 8: Remove country
        public static void RemoveCountryFromDictionary(
            Dictionary<int, string> existingDict,
            int countryCode)
        {
            if (existingDict.ContainsKey(countryCode))
            {
                existingDict.Remove(countryCode);
            }
        }

        // Task 9: Find longest country name
        public static string FindLongestCountryName(Dictionary<int, string> existingDict)
        {
            return existingDict.Values
                               .OrderByDescending(name => name.Length)
                               .FirstOrDefault();
        }
    }

    class Program
    {
        static void Main()
        {
            // Task 2
            Dictionary<int, string> existingDict = DialingCodes.GetExistingDictionary();

            // Task 4
            DialingCodes.AddCountryToExistingDictionary(existingDict, 44, "United Kingdom");

            // Task 5
            string country = DialingCodes.GetCountryNameFromDictionary(existingDict, 91);
            Console.WriteLine("Country for code 91: " + country);

            // Task 7
            DialingCodes.UpdateDictionary(
                existingDict,
                55,
                "Federative Republic of Brazil"
            );

            // Task 8
            DialingCodes.RemoveCountryFromDictionary(existingDict, 1);

            // Task 9
            string longestName = DialingCodes.FindLongestCountryName(existingDict);
            Console.WriteLine("Longest country name: " + longestName);
        }
    }
}
