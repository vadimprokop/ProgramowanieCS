using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Zad3
    {
        public void Start()
        {
            List<string> list = new List<string>();
            while (true)
            {
                String city = Console.ReadLine();
                if (city.Equals("X"))
                {
                    while (true)
                    {
                        char firstLetter = '0';
                        var dictionary = list.GroupBy(x => x[0])
                            .ToDictionary(x => x.Key, x => x.ToList().OrderBy(y => y));
                        if (char.TryParse(Console.ReadLine(), out firstLetter))
                        {
                            if (char.IsLetter(firstLetter))
                            {
                                if (dictionary.ContainsKey(firstLetter))
                                {
                                    string last = dictionary[firstLetter].Last();
                                    foreach (string currentCity in dictionary[firstLetter])
                                    {
                                        Console.Write("{0}", currentCity);
                                        if (!currentCity.Equals(last))
                                        {
                                            Console.Write(", ");
                                        }
                                    }
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine("Puste");
                                }
                            }
                            else if (firstLetter == '0')
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("This is not a letter");
                            }
                        }
                        else
                        {
                            Console.WriteLine("This not a char");
                        }
                    }
                }
                else
                {
                    list.Add(city);
                    continue;
                }
                break;
            }
        }
    }
}