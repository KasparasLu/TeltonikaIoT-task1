using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare
{
    class Model
    {
        public string name { get; set; }
        public List<string> comparableID { get; set; }
        public List<string> comparableValue { get; set; }
        public List<string> displayID { get; set; }
        public List<string> displayValue { get; set; }

        public Model(string nam, List<string> comp_ID, List<string> comp_Value, List<string> disp_ID, List<string> disp_Value)
        {
            name = nam;
            comparableID = comp_ID;
            comparableValue = comp_Value;
            displayID = disp_ID;
            displayValue = disp_Value;
        }

        public void printDescription()
        {
            Console.WriteLine("printing informaion on model {0}", name);
            for (int i = 0; i < displayID.Count; i++)
            {
                Console.WriteLine("{0}: {1}", displayID[i], displayValue[i]);
            }
            Console.WriteLine();
        }
    }
}
