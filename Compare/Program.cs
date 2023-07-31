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
            string idFilter = "";
            var resultFilter = new HashSet<string>();

            var menu          = new Menu();
            var fileManaging  = new FileManaging();

            new Declare().path();
            
            chooseModels:
            string sourcePath = fileManaging.userSelectedPath(menu.ModelMenu()); //Ima declarinta path nuo dabartinio directory (bin) reikia kad imtu nuo root
            string targetPath = fileManaging.userSelectedPath(menu.ModelMenu());
            
            var dataManaging    = new DataManaging();
            var source = dataManaging.getData(sourcePath);
            var target = dataManaging.getData(targetPath);

            var results = new ResultsManaging().getResults(source, target);

            var userInput       = new UserInput();
            var filterManaging  = new FilterManaging();
            
            menuStart:
            userInput.continue_program();

            Console.Clear();
            source.printDescription();
            target.printDescription();

            menu.printMenu(menu.FeatureMenu);
            switch(userInput.userSelectedChoice(menu.FeatureMenu.Length))
            {
                case 1:
                    fileManaging.showFileNames(source, target);
                    goto menuStart;

                case 2:
                    new PrintingResults().printResults(results.Item1, results.Item2, idFilter, resultFilter);
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
                    new DisplayFilters().displayAllFilters(idFilter, resultFilter);
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
