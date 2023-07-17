using static Compare.UserInput;
using static Compare.Menu;

namespace Compare
{
    internal class FileManaging
    {
        private static string _dataPath = @"C:\Users\iot2\Desktop\Praktikos uždaviniai\1 užduotis\Compare\data";
        protected internal static string DataPath
        {
            get { return _dataPath; }
        }
        public void showFileNames(Model source, Model target)
        {
            Console.WriteLine("Chosen source is {0} and target is {1}", source.name, target.name);
        }
        public string userSelectedPath(string[] models)
        {
            var userInput = new UserInput();
            printMenu(models);
            Console.WriteLine("Chose the source file: ");
            string path = models[userInput.userSelectedChoice(models.Length) - 1];
            Console.Clear();
            return path;
        }
    }
}
