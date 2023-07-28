using System.IO;
using System.IO.Compression;
using static Compare.FileManaging;
using static System.Net.Mime.MediaTypeNames;

namespace Compare
{
    internal class DataManaging
    {
        public string[] readData(string path)
        {
            string file = "";
            using (FileStream reader = File.OpenRead(path))
            using (GZipStream zip = new GZipStream(reader, CompressionMode.Decompress, true))
            using (StreamReader unzip = new StreamReader(zip))
                while (!unzip.EndOfStream) file += unzip.ReadLine();
            return file.Split(new char[] { ';', ':' });
        }
        public Model getData(string path)
        {
            string[] pairs = readData(path);
            var compareId    = new List<string>();
            var compareValue = new List<string>();
            var displayId    = new List<string>();
            var displayValue = new List<string>();
            for (int i = 0; i < pairs.Length - 1; i += 2)
            {
                if (!int.TryParse(pairs[i], out int temporaryIntValue) && !double.TryParse(pairs[i], out double tempDoubleValue))
                {
                    displayId.Add(pairs[i]);
                    displayValue.Add(pairs[i + 1]);
                }
                else
                {
                    compareId.Add(pairs[i]);
                    compareValue.Add(pairs[i + 1]);
                }
            }
            return new Model(path.Substring(new Menu().DataPath.Length + 1), compareId, compareValue, displayId, displayValue);
        }
    }
}
