using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Semipermutation
{
    public static class Multioperation3Utils
    {
        public static bool IsCorrentLength(string s)
        {
            if (s.Length == 3 || s.Length == 9 || s.Length == 27)
            {
                return true;
            }
            return false;
        }
        public static bool CheckInputString(string s)
        {
            if (Regex.IsMatch(s, "[^0-7 ]"))
            {
                Console.WriteLine("Ошибка! Компоненты мультиоперации должны быть [0-7]", s);
                Console.Read();
                System.Environment.Exit(1);
                return false;
            }
            s = s.Replace(" ", string.Empty);
            if (!IsCorrentLength(s))
            {
                Console.WriteLine("Ошибка! Длина строки \"{0}\" должна быть кратна 3", s);
                Console.Read();
                System.Environment.Exit(1);
                return false;   
            }
            return true;
        }
        public static List<Multioperation3> ReadSetFromFile(string filename)
        {
            List<Multioperation3> list = new List<Multioperation3>();
            var lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                if (!CheckInputString(line))
                {
                    return null;
                }
                line.Replace(" ", string.Empty);
                list.Add(new Multioperation3(line));
            }
            return list;
        }
    }
}