using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Location
    {
        public string name { get; set; }
        public List<NonPlayerCharacter> npcs ;
        public bool isUnlocked;
        public Location(string name, bool isUnlocked)
        {
            npcs = new List<NonPlayerCharacter>();
            this.name = name;
            this.isUnlocked = isUnlocked;
        }
        public void ShowNPCs()
        {
            for(int i = 0; i < npcs.Count; ++i)
            {
                Console.WriteLine("[{0}] Porozmawiaj z {1}", i, npcs[i].name);
            }
            Console.WriteLine("[T] Podruzuj");
        }
        public void AddNonPlayerCharacter(NonPlayerCharacter nonPlayerCharacter)
        {
            npcs.Add(nonPlayerCharacter);
        }
    }
}
