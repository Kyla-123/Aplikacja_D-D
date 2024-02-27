using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Equipment
    {
        public List<string> Items { get; set; } = new List<string>();
        public bool Armor { get; set; }
        public bool Sword { get; set; }
        public bool Bow { get; set; }
        public bool Wand { get; set; }
        public bool Book { get; set; }
        public bool Tambourine { get; set; }

        public Equipment()
        {
            Armor = false;
            Sword = false;
            Bow = false;
            Wand = false;
            Book = false;
            Tambourine = false;
        }

        public void EquipItem(string item)
        {
            switch (item.ToLower())
            {
                case "armor":
                    Armor = true;
                    break;
                case "sword":
                    Sword = true;
                    break;
                case "bow":
                    Bow = true;
                    break;
                case "wand":
                    Wand = true;
                    break;
                case "book":
                    Book = true;
                    break;
                case "tambourine":
                    Tambourine = true;
                    break;
                default:
                    Console.WriteLine("Unknown item.");
                    break;
            }
        }
    }
}
