using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare
{
    public class Declare
    {

        public void CustomPath() 
        {
            Console.Write("Enter the path to the folder with the data.cfg files(The path shouldn't contain any spaces):");

            choosePath:
            var path = Console.ReadLine();
            if (IsValidFilePath(@$"{path}"))
            {
                new Menu().SetDataPath(path);
            }
            else goto choosePath;
            Console.Clear();
        }

        public bool IsValidFilePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || path.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
            {
                Console.WriteLine("The path is either empty or contains invalid characters");
                return false;
            }
            if (!Directory.Exists(path))
            {
                Console.WriteLine("The directory doesn't exist");
                return false;
            }
            if (Directory.GetFiles(path, "*.cfg").Length == 0)
            {
                Console.WriteLine("The directory doesn't contain .cfg files");
                return false;
            }

            return true;
        }
    }
}
