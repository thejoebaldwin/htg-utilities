using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HTG.Utilities.ReplaceInFile
{
    class Program
    {
        private static string filename = "";
        private static string searchFor = "";
        private static string replaceWith = "";

        static void Main(string[] args)
        {
            if (args.Length >= 6)
            {
                filename = args[1];
                searchFor = args[3];
                replaceWith = args[5];



                FileStream fs = File.Open(filename, FileMode.Open, FileAccess.ReadWrite);
                StreamReader reader = new StreamReader(fs);
                string contents = reader.ReadToEnd();

                contents = contents.Replace(searchFor, replaceWith);
                contents = contents.Replace("{{newline}}", "\n");
                StreamWriter writer = new StreamWriter(fs);
                writer.Write(contents);
                writer.Close();
                reader.Close();
                fs.Close();
            }
            else
            {
                Console.WriteLine("Incorrect Parameters. usage: -filename <filename> -searchfor <searchfor> -replacewith <replacewith>");
            }



        }
    }
}
