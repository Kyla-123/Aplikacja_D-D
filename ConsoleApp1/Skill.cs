using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Skill
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string AttributeAffected { get; set; }
        public int AttributeModifier { get; set; }

        public Skill(string name, int level, string attributeAffected, int attributeModifier)
        {
            Name = name;
            Level = level;
            AttributeAffected = attributeAffected;
            AttributeModifier = attributeModifier;
        }
    }
}
