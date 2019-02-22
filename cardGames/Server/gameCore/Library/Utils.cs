using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Server.gameCore.Cards;

namespace Server.gameCore.Library
{
    public static class Utils
    {
        public static Type[] GetTypesInNamespace(string nameSpace)
        {
            return Assembly.GetExecutingAssembly().GetTypes().Where(t =>
                String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
        }

        public static object MagicallyCreateInstance(string className)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var type = assembly.GetTypes()
                .First(t => t.Name == className);

            return Activator.CreateInstance(type);
        }

        public static List<Color> GetColorsNames()
        {
            return Enum.GetValues(typeof(Color)).Cast<Color>().ToList();
        }


        public static List<TE> ShuffleList<TE>(List<TE> inputList)
        {
            List<TE> randomList = new List<TE>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList; //return the new random list
        }
    }
}