using System.Text.RegularExpressions;

namespace ValveKeyValues2Json
{
    public class KeyValuesConverter
    {
        public static string ToJson(string KeyValues)
        {
            var json = KeyValues;

            // remove comments: /* */ and // (double dash)
            json = Regex.Replace(json, @"(@(?:""[^""]*"")+|""(?:[^""\n\\]+|\\.)*""|'(?:[^'\n\\]+|\\.)*')|//.*|/\*(?s:.*?)\*/", "$1");
            // remove comments: /* */ and / (single dash
            json = Regex.Replace(json, @"(@(?:""[^""]*"")+|""(?:[^""\n\\]+|\\.)*""|'(?:[^'\n\\]+|\\.)*')|/.*|/\*(?s:.*?)\*/", "$1");

            //complement ":" before open braces
            json = Regex.Replace(json, "\"([^\"]*)\"(\\s*){", "\"${1}\": {");

            // place ":" between key/value
            json = Regex.Replace(json, "\"([^\"]*)\"\\s*\"([^\"]*)\"", "\"${1}\": \"${2}\",");

            //remove trailing commas
            json = Regex.Replace(json, ",(\\s*[}\\]])", "${1}");

            //add commas
            json = Regex.Replace(json, "([}\\]])(\\s*)(\"[^\"]*\":\\s*)?([{\\[])", "${1},${2}${3}${4}");

            //object as value
            json = Regex.Replace(json, "}(\\s*\"[^\"]*\":)", "},${1}");

            return string.Concat("{\n", json, "\n}");
        }
    }
}