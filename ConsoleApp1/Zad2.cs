using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Zad2
    {
        public void StartZad()
        {
            int N;
            int M;
            if (int.TryParse(Console.ReadLine(), out N) && int.TryParse(Console.ReadLine(), out M))
            {
                Random rnd = new Random();
                IEnumerable<IEnumerable<int>> list = Enumerable
                    .Range(1, N)
                    .Select(x => Enumerable
                                .Range(1, M)
                                .Select(y => rnd.Next(1, 50))
                            );
                Console.WriteLine("Sum = {0}", list.SelectMany(x => x).Sum());
            }
            else
            {
                Console.WriteLine("Not number");
            }
            Console.ReadKey();
        }

    }
}