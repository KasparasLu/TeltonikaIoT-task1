﻿using static Compare.FileManaging;
using System;

namespace Compare
{
    internal class Menu
    {
        public static string _dataPath;
        public string GetDataPath()
        {
            return _dataPath;
        }

        public void SetDataPath(string path)
        {
            _dataPath = @$"{path}";
        }

        public void PrintMenu(string[] menu)
        {
            Console.WriteLine("Choose from the listed below:");
            for(int i=0; i<menu.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i+1, menu[i]);
            }
        }

        private string[] _resultMenu = { "Unchanged", "Modified", "Removed", "Added" };

        protected internal string[] ResultMenu
        {
            get { return _resultMenu; }
        }

        private string[] _featureMenu = { "Show file names", "Print comparison", "Add ID filter", "Add result filter", "clear filters", "display filters", "select new source and target", "declare a new path", "exit" };

        protected internal string[] FeatureMenu
        {
            get { return _featureMenu; }
        }

        public string[] ModelMenu()
        {
            return Directory.GetFiles(GetDataPath(), "*.cfg");
        }
    }
}
