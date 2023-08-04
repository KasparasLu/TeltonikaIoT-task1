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

            choosePath:
            new Declare().CustomPath();
            
            chooseModels:
            string sourcePath = fileManaging.UserSelectedPath(menu.ModelMenu(), "source"); //Ima declarinta path nuo dabartinio directory (bin) reikia kad imtu nuo root
            string targetPath = fileManaging.UserSelectedPath(menu.ModelMenu(), "target");
            
            var dataManaging    = new DataManaging();
            var source = dataManaging.GetData(dataManaging.ReadData(File.OpenRead(sourcePath)), Path.GetFileName(sourcePath));
            var target = dataManaging.GetData(dataManaging.ReadData(File.OpenRead(targetPath)), Path.GetFileName(targetPath));

            var results = new ResultsManaging().GetResults(source, target);

            var userInput       = new UserInput();
            var filterManaging  = new FilterManaging();
            
            menuStart:
            userInput.ContinueProgram();

            Console.Clear();
            source.PrintDescription();
            target.PrintDescription();

            menu.PrintMenu(menu.FeatureMenu);
            switch(userInput.UserSelectedChoice(menu.FeatureMenu.Length))
            {
                case 1:
                    fileManaging.ShowFileNames(source, target);
                    goto menuStart;

                case 2:
                    new PrintingResults().PrintResults(results.Item1, results.Item2, idFilter, resultFilter);
                    goto menuStart;

                case 3:
                    idFilter = filterManaging.AddIdFilter();
                    goto menuStart;

                case 4:
                    resultFilter = filterManaging.AddResultFilter(resultFilter);
                    goto menuStart;

                case 5:
                    (idFilter, resultFilter) = filterManaging.ClearFilters(idFilter, resultFilter);
                    goto menuStart;

                case 6:
                    new DisplayFilters().DisplayAllFilters(idFilter, resultFilter);
                    goto menuStart;

                case 7:
                    goto chooseModels;

                case 8:
                    goto choosePath;

                case 9:
                    goto endProgram;
            };
            endProgram:
            Console.WriteLine("Thank you for using the application. Goodbye!");
        }
    }
}
