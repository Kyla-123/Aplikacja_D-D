using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SpecificSkills
    {
        public static Skill Swordsmanship = new Skill("Walka Mieczem", 1, "Strength", 3);
        public static Skill Archery = new Skill("Strzelnictwo", 1, "Dexterity", 3);
        public static Skill ToughSkin = new Skill("Twarda Skóra", 1, "Constitution", 4);
        public static Skill Spellcasting = new Skill("Czarowanie", 1, "Intelligence", 3);
        public static Skill Sage = new Skill("Mędrzec", 1, "Wisdom", 3);
        public static Skill SilverTongue = new Skill("Złotousty", 1, "Charisma", 3);
    }
}
