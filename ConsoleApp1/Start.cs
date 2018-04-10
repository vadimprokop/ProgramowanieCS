using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Start
    {
        List<Location> listLocations;
        private bool flag; //check for last npc statement and exit from recursion

        public Start()
        {
            listLocations = new List<Location>();
        }
        private String ValidateName(String name)
        {
            String validatedName = name.Trim();
            return (validatedName.Length >= 2 && validatedName.All(char.IsLetter)) ? validatedName : "";
        }
        public void StartGame()
        {
            while (true)
            {
                Console.WriteLine("Witaj w grze Diablo\n" +
                                "[1] Zacznij nową grę\n" +
                                "[X] Zamknij program");
                String command = Console.ReadLine();
                if (command == "X")
                {
                    break;
                }
                else if (command == "1")
                {
                    Console.Clear();
                    String name;
                    EHeroClass eHeroClass = EHeroClass.barbarzynca;
                    while (true)
                    {
                        Console.WriteLine("Give hero name");
                        name = ValidateName(Console.ReadLine());
                        if (name != "")
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Take hero class:\n" +
                                                     "1. barbarzynca\n" +
                                                     "2. paladyn\n" +
                                                     "3. amazonka");
                                if (Enum.TryParse(Console.ReadLine(), out eHeroClass))
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("You chose incorrect hero class\n" +
                                                        "Try again.");
                                }
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You gave incorrect hero name\n" +
                                                "Try again.");
                        }
                    }
                    Hero hero = new Hero(name, eHeroClass);
                    Console.Clear();
                    hero.Write();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    NonPlayerCharacter nonPlayerCharacter1 = new NonPlayerCharacter("Akara");
                    Statements statements = new Statements(nonPlayerCharacter1, hero);
                    statements.CreateNPCDialogPart1();
                    nonPlayerCharacter1.npcDialogPart = statements.GetNPCDialogPart();
                    NonPlayerCharacter nonPlayerCharacter2 = new NonPlayerCharacter("Deckard");
                    statements = new Statements(nonPlayerCharacter2, hero);
                    statements.CreateNPCDialogPart2();
                    nonPlayerCharacter2.npcDialogPart = statements.GetNPCDialogPart();
                    NonPlayerCharacter nonPlayerCharacter3 = new NonPlayerCharacter("Kashya");
                    statements = new Statements(nonPlayerCharacter3, hero);
                    statements.CreateNPCDialogPart3();
                    nonPlayerCharacter3.npcDialogPart = statements.GetNPCDialogPart();
                    Location location1 = new Location("Silverymoon", true);

                    location1.AddNonPlayerCharacter(nonPlayerCharacter1);
                    location1.AddNonPlayerCharacter(nonPlayerCharacter2);
                    location1.AddNonPlayerCharacter(nonPlayerCharacter3);

                    Location location2 = new Location("Kwazo", true);
                    Location location3 = new Location("Elidary", true);
                    Location location4 = new Location("Manta", false);
                    Location location5 = new Location("Uzupik", false);
                    Location location6 = new Location("Drago", false);


                    listLocations.AddRange(
                            new List<Location>() {
                                location1,
                                location2,
                                location3,
                                location4,
                                location5,
                                location6
                            }
                        );

                    ShowLocation(location1, hero);
                    break;
                }
                else
                {
                    Console.WriteLine("\nYou have chosen the wrong command.\n" +
                                       "Try again.");
                }
            }
        }
        private void TalkTo(NPCDialogPart npcDialogPart, DialogParser dialogParser)
        {
            int currentCommand = 0;
            while (true)
            {
                if (npcDialogPart == null || !flag)
                {
                    break;
                }
                else if (npcDialogPart.IsEmpty())
                {
                    if (flag)
                    {
                        npcDialogPart.ShowNPCDialogPart(dialogParser);
                        Console.WriteLine("Press any key to end conversation...");
                        Console.ReadKey();
                        flag = false;
                    }
                    break;
                }
                else
                {
                    npcDialogPart.ShowNPCDialogPart(dialogParser);
                    if (int.TryParse(Console.ReadLine(), out currentCommand))
                    {
                        if (npcDialogPart.GetHeroDialogPart(currentCommand) != null)
                        {
                            flag = true;
                            npcDialogPart = npcDialogPart.GetHeroDialogPart(currentCommand).GetNPCDialogPart(dialogParser);
                            if (npcDialogPart != null)
                            {
                                TalkTo(npcDialogPart, dialogParser);
                            }
                            else
                            {
                                Console.WriteLine("Press any key to end conversation...");
                                Console.ReadKey();
                                flag = false;
                                break;
                            }

                        }
                        else
                        {
                            Console.WriteLine("No current command.\n" +
                                                "Try again.\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nYou have chosen the wrong command.\n" +
                                           "Try again.\n");
                    }
                }
            }

        }
        private void ChangeLocation(Location location, Hero hero)
        {
            Console.Clear();
            Console.WriteLine("Znajdujesz sie w {0}. Gdzie chcesz wyruszyc?\n", location.name);
            List<Location> currentList = listLocations.Where(x => x.isUnlocked && !x.name.Equals(location.name))
                .OrderBy(x => x.name).ToList();
            for (int i = 0; i < currentList.Count(); i++)
            {
                Console.WriteLine("[{0}] {1}", i, currentList[i].name);
            }
            Console.WriteLine("[X] Powrot");
            while (true)
            {
                int numberLocation;
                string com = Console.ReadLine();
                if (com.Equals("X"))
                {
                    ShowLocation(location, hero);
                }
                else if (int.TryParse(com, out numberLocation))
                {
                    if (numberLocation < currentList.Count())
                    {
                        ShowLocation(currentList[numberLocation], hero);
                    }
                    else
                    {
                        Console.WriteLine("No this location");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("\nYou have chosen the wrong command.\n" +
                               "Try again.");
                    continue;
                }
                break;
            }
        }
        private void ShowLocation(Location location, Hero hero)
        {
            DialogParser dialogParser = new DialogParser(hero);
            while (true)
            {
                NonPlayerCharacter currentNPC;
                int numberNPC;
                Console.Clear();
                Console.WriteLine("Znajdujesz sie w {0}. Co chcesz zrobic?\n", location.name);
                location.ShowNPCs();

                Console.WriteLine("[X] Zamknij program");
                
                string command = Console.ReadLine();
                if (command.Equals("X"))
                {
                    break;
                }
                else if(command.Equals("T"))
                {
                    ChangeLocation(location, hero);
                    break;
                }
                else if (int.TryParse(command, out numberNPC))
                {
                    if(numberNPC < location.npcs.Count)
                    {
                        currentNPC = location.npcs[numberNPC];
                        flag = true;
                        Console.Clear();
                        TalkTo(currentNPC.StartTalking(), dialogParser);
                    }
                    else
                    {
                        Console.WriteLine("\nYou have chosen the wrong command.\n" +
                                       "Try again.\n");
                    }
                }
                else
                {
                    Console.WriteLine("\nYou have chosen the wrong command.\n" +
                                       "Try again.");
                }
            }
        }
    }
}

