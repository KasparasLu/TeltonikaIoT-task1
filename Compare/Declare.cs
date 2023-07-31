using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare
{
    internal class Declare
    {

        public void path() 
        {
            Console.Write("Enter the path to the folder with the data.cfg files(The path shouldn't contain any spaces):");

            choosePath:
            var path = Console.ReadLine();
            if (IsValidFilePath($@"{path}"))
            {
                new Menu().setDataPath($@"{path}");
            }
            else goto choosePath;
            Console.Clear();
        }

        public bool IsValidFilePath(string path)
        {
            // Check if the path is null, empty, or contains invalid characters
            if (string.IsNullOrWhiteSpace(path) || path.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
            {
                Console.WriteLine("The path is either empty or contains invalid characters");
                return false;
            }
            if (string.Equals(path, new Menu().getDataPath(), StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("yeah they the same");
                new UserInput().continue_program();
            }
            else Console.WriteLine("Nah they diff");
            // Check if the directory exists (optional)
            if (!Directory.Exists(path))
            {
                Console.WriteLine(path);
                Console.WriteLine("The directory doesn't exist");
                return false;
            }
            // Check if there are 
            if (Directory.GetFiles(path, "*.cfg").Length == 0)
            {
                Console.WriteLine("The directory doesn't contain .cfg files");
                return false;
            }

            // You can add more checks as per your requirements (e.g., file existence, permissions, etc.)

            return true;
        }
    }
}
