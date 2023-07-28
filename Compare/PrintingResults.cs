using System;
using static Compare.Cosmetics;

namespace Compare
{
    internal class PrintingResults
    {
        private string _format = "{0, 9}| {1, 35}| {2, 9}| {3, 35}| {4}";
        protected internal string Format
        {
            get { return _format; }
        }
        public void printResults(List<Comparison> comparisons, int[] resultCounter, string idFilter, HashSet<string> resultFilter)
        {

            printResultsTable(comparisons, idFilter, resultFilter);

            printResultsCount(resultCounter);

        }
        public void printResultsTable(List<Comparison> results, string idFilter, HashSet<string> resultFilter)
        {
            Console.WriteLine(Format, "Source ID", "Source value", "Target ID", "Target value", "Result");
            for (int i = 0; i < results.Count; i++)
            {
                if (!new Cosmetics().checkFilters(idFilter, resultFilter, results[i])) continue;
                Console.WriteLine(Format, results[i].sourceId, results[i].sourceValue, results[i].targetId, results[i].targetValue, results[i].result);
            }
        }
        public void printResultsCount(int[] resultCounter)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            for (int i = 0; i < resultCounter.Length; i++)
                Console.WriteLine("{0}: {1}", "UMRA"[i], resultCounter[i]);

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
