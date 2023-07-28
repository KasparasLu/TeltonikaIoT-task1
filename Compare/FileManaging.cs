using static Compare.UserInput;
using static Compare.Menu;

namespace Compare
{
    internal class FileManaging
    {
        public void showFileNames(Model source, Model target)
        {
            Console.WriteLine("Chosen source is {0} and target is {1}", source.name, target.name);
        }
        public string userSelectedPath(string[] models)
        {
            new Menu().printMenu(models);
            Console.WriteLine("Chose the source file: ");
            string path = models[new UserInput().userSelectedChoice(models.Length) - 1];
            Console.Clear();
            return path;
        }
    }
}
