using static Compare.Menu;

namespace Compare
{
    internal class FilterManaging
    {
        public string AddIdFilter()
        {
            Console.WriteLine("Enter the desired id filter:");
            string filter = Console.ReadLine();
            Console.WriteLine("The filter is added");
            return filter;
        }
        public HashSet<string> AddResultFilter(HashSet<string> filter)
        {
            var menu = new Menu();
            menu.PrintMenu(menu.ResultMenu);
            int index = new UserInput().UserSelectedChoice(menu.ResultMenu.Length);
            filter.Add(menu.ResultMenu[index - 1]);
            Console.WriteLine("The result filter has been updated");
            return filter;
        }
        public (string, HashSet<string>) ClearFilters(string idFilter, HashSet<string> resultFilter)
        {
            idFilter = "";
            resultFilter.Clear();
            Console.WriteLine("The filters were cleared");
            return (idFilter, resultFilter);
        }
    }
}
