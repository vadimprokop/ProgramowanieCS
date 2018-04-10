using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class NPCDialogPart : IDialogPart
    {
        public string statement { get; }

        NonPlayerCharacter nonPlayerCharacter;
        List<HeroDialogPart> heroDialogParts = new List<HeroDialogPart>();
        public NPCDialogPart(string statement, NonPlayerCharacter nonPlayerCharacter)
        {
            this.nonPlayerCharacter = nonPlayerCharacter;
            this.statement = statement;
        }
        public void AddHeroDialogPart(HeroDialogPart heroDialogPart)
        {
            heroDialogParts.Add(heroDialogPart);
        }
        public void ShowNPCDialogPart(DialogParser dialogParser)
        {
            Console.WriteLine("{0}: {1}", nonPlayerCharacter.name, dialogParser.ParseDialog(this));
            foreach(HeroDialogPart heroDialogPart in heroDialogParts)
            {
                heroDialogPart.ShowHeroDialogPart(dialogParser);
            }
        }
        public HeroDialogPart GetHeroDialogPart(int idHeroDialogPart)
        {
            return heroDialogParts[idHeroDialogPart];
        }
        public bool IsEmpty()
        {
            return (heroDialogParts.Count == 0) ? true : false;
        }
    }
}
