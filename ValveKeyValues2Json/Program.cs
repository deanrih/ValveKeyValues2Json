using System.IO;

namespace ValveKeyValues2Json
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = string.Concat(Directory.GetCurrentDirectory(), "\\files\\");

            var npc_heroes = KeyValuesConverter.ToJson(File.ReadAllText(string.Concat(path, "npc_heroes.txt")));
            var npc_abilities = KeyValuesConverter.ToJson(File.ReadAllText(string.Concat(path, "npc_abilities.txt")));
            var items = KeyValuesConverter.ToJson(File.ReadAllText(string.Concat(path, "items.txt")));
        }
    }
}