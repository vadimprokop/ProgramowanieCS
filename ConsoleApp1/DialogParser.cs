using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DialogParser
    {
        Hero hero;
        public DialogParser(Hero hero)
        {
            this.hero = hero;
        }
        public string ParseDialog(IDialogPart dialogPart)
        {
            return dialogPart.statement.Replace("#HERONAME#", hero.name);
        }
    }
}
