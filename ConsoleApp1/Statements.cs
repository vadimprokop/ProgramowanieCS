using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Statements
    {
        private NPCDialogPart npcDialogPart;
        private NonPlayerCharacter nonPlayerCharacter;
        private Hero hero;
        public Statements(NonPlayerCharacter nonPlayerCharacter, Hero hero)
        {
            this.nonPlayerCharacter = nonPlayerCharacter;
            this.hero = hero;
        }
        public void CreateNPCDialogPart1()
        {
            npcDialogPart = new NPCDialogPart("Witaj, czy mozesz mi pomoc dostac sie do innego miasta?", nonPlayerCharacter);
            NPCDialogPart npcDialogPart2 = new NPCDialogPart("Dziękuję! W nagrodę otrzymasz ode mnie 100 sztuk złota", nonPlayerCharacter);
            NPCDialogPart npcDialogPart3 = new NPCDialogPart("Niestety nie mam wiecej. Jestem bardzo biedny", nonPlayerCharacter);
            NPCDialogPart npcDialogPart4 = new NPCDialogPart("Dziękuję.", nonPlayerCharacter);
            HeroDialogPart heroDialogPart1 = new HeroDialogPart(npcDialogPart2, "Tak, chetnie pomoge", 0, hero);
            HeroDialogPart heroDialogPart2 = new HeroDialogPart(null, "Nie, nie pomogę, żegnaj.", 1, hero);
            HeroDialogPart heroDialogPart3 = new HeroDialogPart(null, "Dam znac jak bede gotowy", 0, hero);
            HeroDialogPart heroDialogPart4 = new HeroDialogPart(npcDialogPart3, "100 sztuk zlota to za malo!", 1, hero);
            HeroDialogPart heroDialogPart5 = new HeroDialogPart(npcDialogPart4, "OK, może byc 100 sztuk zlota.", 0, hero);
            HeroDialogPart heroDialogPart6 = new HeroDialogPart(null, "W takim razie radz sobie sam.", 1, hero);
            npcDialogPart.AddHeroDialogPart(heroDialogPart1);
            npcDialogPart.AddHeroDialogPart(heroDialogPart2);
            npcDialogPart2.AddHeroDialogPart(heroDialogPart3);
            npcDialogPart2.AddHeroDialogPart(heroDialogPart4);
            npcDialogPart3.AddHeroDialogPart(heroDialogPart5);
            npcDialogPart3.AddHeroDialogPart(heroDialogPart6);
        }
        public void CreateNPCDialogPart2()
        {
            npcDialogPart = new NPCDialogPart("Witaj, czy chcesz cos kupic?", nonPlayerCharacter);
            NPCDialogPart npcDialogPart2 = new NPCDialogPart("Mam miecz, katane, bulawe, cos chcesz kupic?", nonPlayerCharacter);
            NPCDialogPart npcDialogPart3 = new NPCDialogPart("100 sztuk zlota.", nonPlayerCharacter);
            NPCDialogPart npcDialogPart4 = new NPCDialogPart("200 sztuk zlota.", nonPlayerCharacter);
            NPCDialogPart npcDialogPart5 = new NPCDialogPart("300 sztuk zlota.", nonPlayerCharacter);
            NPCDialogPart npcDialogPart6 = new NPCDialogPart("Dziękuję.", nonPlayerCharacter);
            HeroDialogPart heroDialogPart1 = new HeroDialogPart(npcDialogPart2, "Tak, chetnie kupe. Co masz?", 0, hero);
            HeroDialogPart heroDialogPart2 = new HeroDialogPart(null, "Nie, dziekuje.", 1, hero);
            HeroDialogPart heroDialogPart3 = new HeroDialogPart(npcDialogPart3, "Mecz, ile kosztuje?", 0, hero);
            HeroDialogPart heroDialogPart4 = new HeroDialogPart(npcDialogPart4, "Katana ile kosztuje?", 1, hero);
            HeroDialogPart heroDialogPart5 = new HeroDialogPart(npcDialogPart5, "Bulawa ile kosztuje?", 2, hero);
            HeroDialogPart heroDialogPart6 = new HeroDialogPart(null, "Nic.Do widzenia.", 3, hero);
            HeroDialogPart heroDialogPart7 = new HeroDialogPart(npcDialogPart6, "Ok. Biore.", 0, hero);
            HeroDialogPart heroDialogPart8 = new HeroDialogPart(null, "Nie, Drogo, Do widzenia", 1, hero);
            npcDialogPart.AddHeroDialogPart(heroDialogPart1);
            npcDialogPart.AddHeroDialogPart(heroDialogPart2);
            npcDialogPart2.AddHeroDialogPart(heroDialogPart3);
            npcDialogPart2.AddHeroDialogPart(heroDialogPart4);
            npcDialogPart2.AddHeroDialogPart(heroDialogPart5);
            npcDialogPart2.AddHeroDialogPart(heroDialogPart6);
            npcDialogPart3.AddHeroDialogPart(heroDialogPart7);
            npcDialogPart3.AddHeroDialogPart(heroDialogPart8);
            npcDialogPart4.AddHeroDialogPart(heroDialogPart7);
            npcDialogPart4.AddHeroDialogPart(heroDialogPart8);
            npcDialogPart5.AddHeroDialogPart(heroDialogPart7);
            npcDialogPart5.AddHeroDialogPart(heroDialogPart8);
        }
        public void CreateNPCDialogPart3()
        {
            npcDialogPart = new NPCDialogPart("Hej czy to Ty jestes tym slynnym #HERONAME# – pogromca smokow?", nonPlayerCharacter);
            NPCDialogPart npcDialogPart2 = new NPCDialogPart("WOW! Milo poznac!", nonPlayerCharacter);
            HeroDialogPart heroDialogPart1 = new HeroDialogPart(npcDialogPart2, "Tak, jestem #HERONAME#", 0, hero);
            HeroDialogPart heroDialogPart2 = new HeroDialogPart(null, "Nie.", 1, hero);
            npcDialogPart.AddHeroDialogPart(heroDialogPart1);
            npcDialogPart.AddHeroDialogPart(heroDialogPart2);
        }
        public NPCDialogPart GetNPCDialogPart()
        {
            return npcDialogPart;
        }
    }
}