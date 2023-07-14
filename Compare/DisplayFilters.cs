using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare
{
    internal class DisplayFilters
    {
        public void displayAllFilters(string id, HashSet<string> result)
        {
            displayIdFilters(id);

            displayResultFilters(result);
        }

        public void displayIdFilters(string id)
        {
            if (id == "") Console.WriteLine("Currently the id filter doesnt exist");
            else Console.WriteLine("ID filter is: {0}", id);
        }

        public void displayResultFilters(HashSet<string> result)
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
