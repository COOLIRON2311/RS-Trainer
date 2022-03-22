using System.Linq;
using System.IO;

namespace RS_Trainer
{
    public class RadioData
    {
        public string Adress { get; private set; }
        public string[] Key { get; private set; }
        public string CheckSum { get; private set; }
        public string[] Freq { get; private set; }
        private static string Slice(string s)
        {
            int i = s.IndexOf('!');
            if (i >= 0)
                return s.Substring(0, i).Trim();
            return s;
        }
        public RadioData(string file)
        {
            string[] lines = File.ReadAllLines(file).Select(x => Slice(x)).Where(x => x.Length > 0).ToArray();
            Adress = lines[0];
            Key = lines.Skip(1).Take(8).ToArray();
            CheckSum = lines[9];
            Freq = lines.Skip(10).Take(6).ToArray();
        }
    }
}

