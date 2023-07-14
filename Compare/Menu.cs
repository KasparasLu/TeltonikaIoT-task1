using static Compare.FileManaging;

namespace Compare
{
    internal class Menu
    {
        public static void printMenu(string[] menu)
        {
            Console.WriteLine("Choose from the listed below:");
            for(int i=0; i<menu.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i+1, menu[i]);
            }
        }

        private static string[] _resultMenu = { "Unchanged", "Modified", "Removed", "Added" };

        protected internal static string[] ResultMenu
        {
            get { return _resultMenu; }
        }

        private static string[] _featureMenu = { "Show file names", "Print comparison", "Add ID filter", "Add result filter", "clear filters", "display filters", "select new source and target", "exit" };

        protected internal static string[] FeatureMenu
        {
            get { return _featureMenu; }
        }

        private static string[] _models = Directory.GetFiles(DataPath);

        protected internal static string[] ModelMenu
        {
            get { return _models; }
        }
    }
}
