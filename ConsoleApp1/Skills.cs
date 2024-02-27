using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Skills
    {
        private List<Skill> skillsList;

        public Skills()
        {
            skillsList = new List<Skill>();
        }

        public void AddSkill(string name, int level, string attributeAffected, int attributeModifier)
        {
            var skill = skillsList.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (skill == null)
            {
                skillsList.Add(new Skill(name, level, attributeAffected, attributeModifier));
            }
            else
            {
                // Jeśli umiejętność już istnieje, możemy zaktualizować jej poziom i modyfikatory atrybutów.
                skill.Level = level;
                skill.AttributeAffected = attributeAffected;
                skill.AttributeModifier = attributeModifier;
            }
        }


        public List<Skill> GetAllSkills()
        {
            return skillsList;
        }
    }
}
