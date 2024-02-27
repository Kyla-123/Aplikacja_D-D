using ConsoleApp1;
using System;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static CharacterManager characterManager = new CharacterManager();

    public static List<Character> LoadCharactersFromTxt(string filePath)
    {
        var characters = new List<Character>();
        var lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            var properties = line.Split(';');
            var character = new Character();

            foreach (var prop in properties)
            {
                var keyValue = prop.Split(':');
                var key = keyValue[0].Trim();
                var value = keyValue[1].Trim();

                switch (key)
                {
                    case "Name":
                        character.Name = value;
                        break;
                    case "Race":
                        character.Race = value;
                        break;
                    case "Class":
                        character.Class = value;
                        break;
                    case "HealthPoints":
                        character.HealthPoints = int.Parse(value);
                        break;
                    case "ManaPoints":
                        character.ManaPoints = int.Parse(value);
                        break;
                }
            }

            characters.Add(character);
        }

        return characters;
    }
    public static void Main(string[] args)
    {

        string filePath = @"C:\Users\Greee\source\repos\ConsoleApp1\ConsoleApp1\characters.txt";
        var characters = LoadCharactersFromTxt(filePath);

        // Przekazanie wczytanych postaci do menedżera postaci
        foreach (var character in characters)
        {
            characterManager.AddCharacter(character);
        }
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Dungeons & Dragons Character Manager");
            Console.WriteLine("1. Add New Character");
            Console.WriteLine("2. View Characters");
            Console.WriteLine("3. Edit Character");
            Console.WriteLine("4. Delete Character");
            Console.WriteLine("5. View Character Attributes");
            Console.WriteLine("6. Equip Item to Character");
            Console.WriteLine("7. View Character Attributes and Equipment");
            Console.WriteLine("8. Add Skill to Character");
            Console.WriteLine("9. View Character Skills");
            Console.WriteLine("10. Exit");
            Console.Write("Select an option: ");
            

            switch (Console.ReadLine())
            {
                case "1":
                    AddNewCharacter();
                    break;
                case "2":
                    ViewCharacters();
                    break;
                case "3":
                    EditCharacter();
                    break;
                case "4":
                    DeleteCharacter();
                    break;
                case "5":
                    ViewCharacterAttributes();
                    break;
                case "6":
                    EquipItemToCharacter();
                    break;
                case "7":
                    ViewCharacterAttributesAndEquipment();
                    break;
                case "8":
                    AddSkillToCharacter();
                    break;
                case "9":
                    ViewCharacterSkills();
                    break;
                case "10":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }

            if (!exit)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }

    private static void AddNewCharacter()
    {
        Console.Write("Enter character name: ");
        string name = Console.ReadLine();

        Console.Write("Enter race: ");
        string race = Console.ReadLine();

        Console.Write("Enter class: ");
        string characterClass = Console.ReadLine();

        Character newCharacter = new Character(name, race, characterClass);
        characterManager.AddCharacter(newCharacter);
        Console.WriteLine("Character added successfully!");
    }

    private static void ViewCharacters()
    {
        foreach (var character in characterManager.GetAllCharacters())
        {
            Console.WriteLine($"Name: {character.Name}, Race: {character.Race}, Class: {character.Class}");
            Console.WriteLine($"Health Points: {character.HealthPoints}");
            Console.WriteLine($"Mana Points: {character.ManaPoints}");
        }
    }

    private static void EditCharacter()
    {
        Console.Write("Enter the name of the character to edit: ");
        string name = Console.ReadLine();
        var character = characterManager.GetCharacter(name);

        if (character == null)
        {
            Console.WriteLine($"Character with name '{name}' not found.");
            return;
        }

        Console.WriteLine($"Editing character: {name}");
        Console.WriteLine("Available attributes to edit: Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma");
        Console.Write("Enter the attribute you want to edit: ");
        string attribute = Console.ReadLine();

        if (!character.Attributes.ContainsKey(attribute))
        {
            Console.WriteLine($"Attribute {attribute} is not valid.");
            return;
        }

        Console.Write($"Enter new value for {attribute}: ");
        int newValue;
        if (!int.TryParse(Console.ReadLine(), out newValue))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return;
        }

        character.UpdateAttribute(attribute, newValue);
        Console.WriteLine($"{attribute} updated to {newValue}.");
    }
    private static void ViewCharacterAttributes()
{
    while (true)
    {
        Console.Write("Enter the name of the character to view attributes or type 'exit' to go back: ");
        string name = Console.ReadLine();

        if (name.Equals("exit", StringComparison.OrdinalIgnoreCase))
        {
            break;
        }

        var character = characterManager.GetCharacter(name);

        if (character == null)
        {
            Console.WriteLine($"Character with name '{name}' not found. Please try again.");
        }
        else
        {
            Console.WriteLine($"Attributes for {name}:");
            foreach (var attribute in character.Attributes)
            {
                Console.WriteLine($"{attribute.Key}: {attribute.Value}");
            }
            break; // Exit the loop if a valid character is found
        }
    }
}

    private static void DeleteCharacter()
    {
        Console.Write("Enter the name of the character to delete: ");
        string name = Console.ReadLine();

        if (characterManager.RemoveCharacter(name))
        {
            Console.WriteLine("Character deleted successfully.");
        }
        else
        {
            Console.WriteLine($"Character with name '{name}' not found.");
        }
    }
    private static void EquipItemToCharacter()
    {
        Console.Write("Enter the name of the character to equip item: ");
        string name = Console.ReadLine();
        var character = characterManager.GetCharacter(name);

        if (character == null)
        {
            Console.WriteLine($"Character with name '{name}' not found.");
            return;
        }

        Console.Write("Enter the item to equip (Armor, Sword, Bow, Wand, Book, Tambourine): ");
        string item = Console.ReadLine();

        character.EquipItem(item);
        Console.WriteLine($"{item} equipped to {name}.");
    }
    private static void ViewCharacterAttributesAndEquipment()
    {
        Console.Write("Enter the name of the character to view attributes and equipment: ");
        string name = Console.ReadLine();
        var character = characterManager.GetCharacter(name);

        if (character == null)
        {
            Console.WriteLine($"Character with name '{name}' not found.");
            return;
        }

        Console.WriteLine($"Attributes for {name}:");
        foreach (var attribute in character.Attributes)
        {
            Console.WriteLine($"{attribute.Key}: {attribute.Value}");
        }

        Console.WriteLine($"Equipment for {name}:");
        if (character.Equipment.Armor) Console.WriteLine("Armor");
        if (character.Equipment.Sword) Console.WriteLine("Sword");
        if (character.Equipment.Bow) Console.WriteLine("Bow");
        if (character.Equipment.Wand) Console.WriteLine("Wand");
        if (character.Equipment.Book) Console.WriteLine("Book");
        if (character.Equipment.Tambourine) Console.WriteLine("Tambourine");
    }
    private static void AddSkillToCharacter()
    {
        Console.Write("Enter the name of the character to add skill: ");
        string name = Console.ReadLine();
        var character = characterManager.GetCharacter(name);

        if (character == null)
        {
            Console.WriteLine($"Character with name '{name}' not found.");
            return;
        }

        Console.WriteLine("Available skills: Swordsmanship, Archery, ToughSkin, Spellcasting, Sage, SilverTongue");
        Console.Write("Enter the skill you want to add: ");
        string skillName = Console.ReadLine();
        Skill skillToAdd = null;

        switch (skillName.ToLower())
        {
            case "swordsmanship":
                skillToAdd = SpecificSkills.Swordsmanship;
                break;
            case "archery":
                skillToAdd = SpecificSkills.Archery;
                break;
            case "toughskin":
                skillToAdd = SpecificSkills.ToughSkin;
                break;
            case "spellcasting":
                skillToAdd = SpecificSkills.Spellcasting;
                break;
            case "sage":
                skillToAdd = SpecificSkills.Sage;
                break;
            case "silvertongue":
                skillToAdd = SpecificSkills.SilverTongue;
                break;
            default:
                Console.WriteLine("Skill not recognized.");
                return;
        }

        character.CharacterSkills.AddSkill(skillToAdd.Name, skillToAdd.Level, skillToAdd.AttributeAffected, skillToAdd.AttributeModifier);
        character.UpdateAttributesBasedOnSkills();
        Console.WriteLine($"{skillToAdd.Name} added to {name}.");
    }
    private static void ViewCharacterSkills()
    {
        Console.Write("Enter the name of the character to view skills: ");
        string name = Console.ReadLine();
        var character = characterManager.GetCharacter(name);

        if (character == null)
        {
            Console.WriteLine($"Character with name '{name}' not found.");
            return;
        }

        var skills = character.CharacterSkills.GetAllSkills();
        if (skills.Count == 0)
        {
            Console.WriteLine($"{name} has no skills.");
            return;
        }

        Console.WriteLine($"{name}'s skills:");
        foreach (var skill in skills)
        {
            Console.WriteLine($"- {skill.Name}: Level {skill.Level} ({skill.AttributeAffected} +{skill.AttributeModifier})");
        }

        
    }


    
   
    }




