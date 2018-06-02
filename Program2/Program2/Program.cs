using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Semipermutation
{
    class Program2
    {
        static void Main(string[] args)
        {
            try
            {
                string s1, s2;
                int mode = 0;
                do
                {
                    Console.WriteLine("Choose mode: 0 - manual, 1 - from file");
                    mode = Convert.ToInt32(Console.ReadLine());
                } while ((mode != 0) & (mode != 1));
                //Console.Readline();
                switch (mode)
                {
                    case 0:
                        do
                        {
                            while ((s1 = ReadMultioperationFromKeyboad()) == null) ;
                            while ((s2 = ReadMultioperationFromKeyboad()) == null) ;
                            Multioperation3 mop1 = new Multioperation3(s1);
                            Multioperation3 mop2 = new Multioperation3(s2);
                            if (mop1 < mop2)
                                Console.WriteLine("Мультиоперации перестановочны");
                            else
                                Console.WriteLine("Мультиоперации не перестановочны");
                            Console.WriteLine("Повторить ввод? [0/1]");
                            mode = Convert.ToInt32(Console.ReadLine());
                            // Console.Read();
                        } while (mode != 0);
                        break;
                    case 1:
                        Console.WriteLine("Введите название файла,содержащего мультиоперации Fi");

                        string filename_f = Console.ReadLine();
                        if (!File.Exists(filename_f))
                        {
                            Console.WriteLine("Ошибка! Файла с таким именем не сущетсвует. Повторите еще раз");
                            break;
                        }
                        List<Multioperation3> list_f = Multioperation3Utils.ReadSetFromFile(filename_f);
                        Console.WriteLine("Введите название файла,содержащего мультиоперации Gi");

                        string filename_g = Console.ReadLine();
                        if (!File.Exists(filename_g))
                        {
                            Console.WriteLine("Ошибка! Файла с таким именем не сущетсвует. Повторите еще раз");
                            break;
                        }
                        List<Multioperation3> list_g =
               Multioperation3Utils.ReadSetFromFile(filename_g);
                        foreach (Multioperation3 f in list_f)
                        {
                            foreach (Multioperation3 g in list_g)
                            {
                                Console.WriteLine("Мультиоперации {0}, {1} ", f, g);
                                if (f < g)
                                    Console.WriteLine("перестановочны");
                                else
                                    Console.WriteLine("не перестановочны");
                            }
                        }
                        break;
                }

                Console.ReadKey();
                return;
            }
            catch (System.FormatException e) { Console.WriteLine("Введена буква"); Console.Read(); };
        }

            static string ReadMultioperationFromKeyboad()
        {
            string s;
            Console.WriteLine("Введите мультиоперацию:");
            s = Console.ReadLine();
            if (Regex.IsMatch(s, "[^0-7 ]"))
            {
                Console.WriteLine("Ошибка! Компоненты мультиоперации должны быть [0-7]");
                return null;   
            }
            s = s.Replace(" ", string.Empty);
            if (!Multioperation3Utils.IsCorrentLength(s))
            {
                Console.WriteLine("Ошибка! Некорректная мультиоперация");
                return null;
            }
            return s;
        }
    }
}