using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare
{
    internal class DisplayFilters
    {
        public void DisplayAllFilters(string id, HashSet<string> result)
        {
            DisplayIdFilters(id);

            DisplayResultFilters(result);
        }

        public void DisplayIdFilters(string id)
        {
            if (id == "") Console.WriteLine("Currently the id filter doesnt exist");
            else Console.WriteLine("ID filter is: {0}", id);
        }

        public void DisplayResultFilters(HashSet<string> result)
        {
            if (result.Count == 0) Console.WriteLine("Currently no result filters exist");
            else
            {
                Console.WriteLine("Result filters:");
                foreach (string r in result) Console.WriteLine(r);
            }
        }
    }
}
