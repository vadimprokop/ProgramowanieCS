using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Hero
    {
        public String name { get; set; }
        public EHeroClass heroClass { get; set; }
        public Hero(String name, EHeroClass heroClass)
        {
            this.name = name;
            this.heroClass = heroClass;
        }
        public void Write()
        {
            Console.WriteLine("{0} {1} wyrusza na przygodę", this.heroClass, this.name);
        }
    }
}