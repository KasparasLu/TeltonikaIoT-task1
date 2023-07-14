﻿using static Compare.UserInput;
using static Compare.Menu;

namespace Compare
{
    internal class FilterManaging
    {
        public string addIdFilter()
        {
            Console.WriteLine("Enter the desired id filter:");
            string filter = Console.ReadLine();
            Console.WriteLine("The filter is added");
            return filter;
        }
        public HashSet<string> addResultFilter(HashSet<string> filter)
        {
            UserInput userInput = new UserInput();
            printMenu(ResultMenu);
            int index = userInput.userSelectedChoice(ResultMenu.Length);
            filter.Add(ResultMenu[index - 1]);
            Console.WriteLine("The result filter has been updated");
            return filter;
        }
        public (string, HashSet<string>) clearFilters(string idFilter, HashSet<string> resultFilter)
        {
            idFilter = "";
            resultFilter.Clear();
            Console.WriteLine("The filters were cleared");
            return (idFilter, resultFilter);
        }
    }
}