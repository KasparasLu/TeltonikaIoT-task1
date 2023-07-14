using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare
{
    internal class UserInput
    {
        public void continue_program()
        {
            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();
        }
        public int userSelectedChoice(int size)
        {
            string input;
            int parsedInput;
            do
            {
                input = Console.ReadLine();
                if (!int.TryParse(input, out parsedInput) || parsedInput < 1 || parsedInput > size) Console.WriteLine("Invalid value, please enter a value which is listed above");
                else break;
            } while (true);
            return parsedInput;
        }
    }
}
