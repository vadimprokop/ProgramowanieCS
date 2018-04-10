using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Zad1
    {
        bool Validate(int number)
        {
            return (number != 5 && number != 9 && (number % 7 == 0 || number % 2 == 1));
        }
        public void StartZad()
        {
            int N;
            if (int.TryParse(Console.ReadLine(), out N))
            {
                IEnumerable<int> squares = Enumerable.Range(1, N).Where(x => Validate(x)).Select(x => x * x).OrderBy(x => x);
                Console.WriteLine("Sum elements = {0}", squares.Sum());
                Console.WriteLine("Amount elements = {0}", squares.Count());
                Console.WriteLine("First element = {0}", squares.First());
                Console.WriteLine("Last element = {0}", squares.Last());
                if (squares.Count() < 3)
                {
                    Console.WriteLine("No third element");
                }
                else
                {
                    Console.WriteLine("Third element = {0}", squares.ElementAt(2));
                }

            }
            else
            {
                Console.WriteLine("Not number");
            }
            Console.ReadKey();
        }
    }
}
