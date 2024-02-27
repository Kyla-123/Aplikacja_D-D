using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;

    public class Character
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public Dictionary<string, int> Attributes { get; set; }
        public Dictionary<string, int> Skills { get; set; }
        public Equipment Equipment { get; set; }
        public Skills CharacterSkills { get; set; }
      
        public int HealthPoints { get; set; }
        public int ManaPoints { get; set; }


        public Character(string name, string race, string characterClass)
        {
            Name = name;
            Race = race;
            Class = characterClass;
            HealthPoints = 10; // Wszyscy bohaterowie zaczynają z 10 HP
            ManaPoints = 10;   // Wszyscy bohaterowie zaczynają z 10 MP
            Attributes = new Dictionary<string, int>()
        {
            {"Strength", 0},
            {"Dexterity", 0},
            {"Constitution", 0},
            {"Intelligence", 0},
            {"Wisdom", 0},
            {"Charisma", 0}
        };
            CharacterSkills = new Skills();
            Equipment = new Equipment();
            
        }

        public Character()
        {
        }

        public void UpdateAttribute(string attribute, int value)
        {
            if (Attributes.ContainsKey(attribute))
            {
                Attributes[attribute] = value;
            }
            else
            {
                throw new ArgumentException("Attribute does not exist.");
            }
        }

        

        public void UpdateAttributesBasedOnEquipment()
        {
            if (Equipment.Armor) Attributes["Constitution"] += 3;
            if (Equipment.Sword) Attributes["Strength"] += 2;
            if (Equipment.Bow) Attributes["Dexterity"] += 2;
            if (Equipment.Wand) Attributes["Intelligence"] += 2;
            if (Equipment.Book) Attributes["Wisdom"] += 2;
            if (Equipment.Tambourine) Attributes["Charisma"] += 2;
        }
        public void EquipItem(string item)
        {
            Equipment.EquipItem(item);
            UpdateAttributesBasedOnEquipment(); // Aktualizuj atrybuty za każdym razem, gdy postać wyposaża nowy przedmiot
        }
        public void UpdateAttributesBasedOnSkills()
        {
            foreach (var skill in CharacterSkills.GetAllSkills())
            {
                switch (skill.AttributeAffected)
                {
                    case "Strength":
                        Attributes["Strength"] += skill.AttributeModifier;
                        break;
                    case "Dexterity":
                        Attributes["Dexterity"] += skill.AttributeModifier;
                        break;
                    case "Constitution":
                        Attributes["Constitution"] += skill.AttributeModifier;
                        break;
                    case "Intelligence":
                        Attributes["Intelligence"] += skill.AttributeModifier;
                        break;
                    case "Wisdom":
                        Attributes["Wisdom"] += skill.AttributeModifier;
                        break;
                    case "Charisma":
                        Attributes["Charisma"] += skill.AttributeModifier;
                        break;
                }

                
            }

        }
    }
  
}
