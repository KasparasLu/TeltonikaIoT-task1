using static Compare.UserInput;
using static Compare.Menu;

namespace Compare
{
    public class FileManaging
    {
        public void ShowFileNames(Model source, Model target)
        {
            Console.WriteLine("Chosen source is {0} and target is {1}", source.name, target.name);
        }
        public string UserSelectedPath(string[] models, string type)
        {
            new Menu().PrintMenu(models);
            Console.WriteLine("Chose the {0} file: ", type);
            string path = models[new UserInput().UserSelectedChoice(models.Length) - 1];
            Console.Clear();
            return path;
        }
    }
}
