using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WoordFinderrz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading...");
            List<string> woorden = new List<string>();

            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("woordenAlleenLetters.txt"));


            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    woorden.Add(line);
                }
            }
              
            Console.Clear();
            List<String> matches = new List<string>();
            while (true)
            {
                matches.Clear();
                Console.WriteLine("Voer uw regex in:");
                string input = Console.ReadLine();
                Regex r = new Regex("^" + input + "$");
                Console.WriteLine();
                Console.WriteLine("De volgende woorden matchen:");
                foreach (string woord in woorden)
                {
                    if (r.IsMatch(woord.ToLower()))
                    {
                        if (!matches.Contains(woord))
                        {
                            matches.Add(woord);
                        }
                    }
                }
                foreach (string match in matches)
                {
                    Console.WriteLine(match);
                }
                Console.WriteLine();
            }
        }
    }
}
