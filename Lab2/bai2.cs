// See https://aka.ms/new-console-template for more information
using System;
using System.Text.RegularExpressions;
using System.Text;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

string[] FileContents = File.ReadAllLines("vnedict.txt");
Dictionary<string, string> dict = new Dictionary<string,string>();
foreach (string line in FileContents)
{
    var keyvalue = Regex.Match(line, @"(.*):(.*)");
    dict.Add(keyvalue.Groups[1].Value.Trim(), keyvalue.Groups[2].Value.Trim());
}
string keyinput = "";
string keyitem = dict[keyinput];
        while (true)
        {
            Console.WriteLine("Hãy nhập từ cần tra: ");
            keyinput = Console.ReadLine();
            if (dict.ContainsKey(keyinput))
            {
                Console.WriteLine(dict[keyinput]);
            }
            else
            {
                Console.WriteLine("Không có từ này trong từ điển");
        }
    }
