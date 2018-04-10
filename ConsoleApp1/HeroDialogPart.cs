using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class HeroDialogPart : IDialogPart
    {
        NPCDialogPart npcDialogPart { get; set; }
        public string statement { get; }
        int idHeroDialogPart { get; set; }
        private Hero hero;
        public HeroDialogPart(NPCDialogPart npcDialogPart, string statement, int idHeroDialogPart, Hero hero)
        {
            this.npcDialogPart = npcDialogPart;
            this.statement = statement;
            this.idHeroDialogPart = idHeroDialogPart;
            this.hero = hero;
        }
        public void ShowHeroDialogPart(DialogParser dialogParser)
        {
            Console.WriteLine("[{0}] {1}: {2}", idHeroDialogPart, hero.name, dialogParser.ParseDialog(this));
        }
        public NPCDialogPart GetNPCDialogPart(DialogParser dialogParser)
        {
            Console.WriteLine("{0}", dialogParser.ParseDialog(this));
            return npcDialogPart;
        }
    }
}
