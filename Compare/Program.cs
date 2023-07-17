using static Compare.PrintingResults;
using static Compare.DisplayFilters;
using static Compare.FilterManaging;
using static Compare.ResultsManaging;
using static Compare.FileManaging;
using static Compare.DataManaging;
using static Compare.UserInput;
using static Compare.Menu;

namespace Compare
{
    class Program
    {
        public static void Main(string[] args)
        {
            var userInput       = new UserInput();
            var fileManaging    = new FileManaging();
            var dataManaging    = new DataManaging();
            var filterManaging  = new FilterManaging();
            var displayFilters  = new DisplayFilters();
            var resultsManaging = new ResultsManaging();
            var printingResults = new PrintingResults();

            string idFilter = "";
            var resultFilter = new HashSet<string>();

            chooseModels:
            string sourcePath = fileManaging.userSelectedPath(ModelMenu);
            string targetPath = fileManaging.userSelectedPath(ModelMenu);
            var source = dataManaging.getData(sourcePath);
            var target = dataManaging.getData(targetPath);

            var results = resultsManaging.getResults(source, target);

            menuStart:
            userInput.continue_program();

            Console.Clear();
            source.printDescription();
            target.printDescription();

            printMenu(FeatureMenu);
            switch(userInput.userSelectedChoice(FeatureMenu.Length))
            {
                case 1:
                    fileManaging.showFileNames(source, target);
                    goto menuStart;

                case 2:
                    printingResults.printResults(results.Item1, results.Item2, idFilter, resultFilter);
                    goto menuStart;

                case 3:
                    idFilter = filterManaging.addIdFilter();
                    goto menuStart;

                case 4:
                    resultFilter = filterManaging.addResultFilter(resultFilter);
                    goto menuStart;

                case 5:
                    (idFilter, resultFilter) = filterManaging.clearFilters(idFilter, resultFilter);
                    goto menuStart;

                case 6:
                    displayFilters.displayAllFilters(idFilter, resultFilter);
                    goto menuStart;

                case 7:
                    goto chooseModels;

                case 8:
                    goto endProgram;
            };
            
            endProgram:
            Console.WriteLine("Thank you for using the application. Goodbye!");
        }
    }
}
