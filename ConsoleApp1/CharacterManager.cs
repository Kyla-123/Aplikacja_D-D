using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CharacterManager
    {
        private List<Character> characters;

        public CharacterManager()
        {
            characters = new List<Character>();
        }

        public void AddCharacter(Character character)
        {
            if (character == null)
            {
                throw new ArgumentNullException(nameof(character), "Character cannot be null.");
            }

            characters.Add(character);
        }
        


        public Character GetCharacter(string name)
        {
            foreach (var character in characters)
            {
                if (character.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return character;
                }
            }

            return null; // Jeśli nie znajdziesz postaci o danym imieniu, zwróć null.
        }

        // Metoda do usuwania postaci
        public bool RemoveCharacter(string name)
        {
            var character = GetCharacter(name);
            if (character != null)
            {
                return characters.Remove(character);
            }

            return false;
        }

        public List<Character> GetAllCharacters()
        {
            return characters;
        }
       
    }

}

