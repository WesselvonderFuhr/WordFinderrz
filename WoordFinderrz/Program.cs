using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WoordFinderrz
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading...");
            List<string> woorden = new List<string>();
            var fileStream = new FileStream(@"C:woorden.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    woorden.Add(line);
                }
            }
            Console.Clear();
            List<String> matches = new List<string>();
            while (true)
            {
                matches.Clear();
                Console.WriteLine("Voer uw tekstpatroon in:");
                string input = Console.ReadLine();
                Regex r = parseRegex(input);
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

        public static Regex parseRegex(string input)
        {
            List<int> usedNumbers = new List<int>();
            string regex = "^";
            foreach(char c in input)
            {
                if (Char.IsDigit(c))
                {
                    int number = int.Parse(c.ToString());
                    if (!usedNumbers.Contains(number))
                    {
                        usedNumbers.Add(number);
                        regex += "(.)";
                    }
                    else
                    {
                        int oldNumber = usedNumbers.FindIndex((x => x == number))+1;
                        regex += "\\" + oldNumber; 
                    }
                    


                }
                else if(Char.IsLetter(c))
                {
                    regex += c;
                }
            }
            regex += "$";
            return new Regex(regex);
        }
    }
}
