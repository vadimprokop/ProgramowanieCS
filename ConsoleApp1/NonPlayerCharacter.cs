using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class NonPlayerCharacter
    {
        public string name { get; set; }
        public NPCDialogPart npcDialogPart { get; set; }
        public NonPlayerCharacter(string name)
        {
            this.name = name;
        }
        public NPCDialogPart StartTalking()
        {
            return npcDialogPart;
        }
    }
}
