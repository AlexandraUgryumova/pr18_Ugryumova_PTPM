using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Угрюмова_18_практика_индивид
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int step = int.Parse(File.ReadAllText("num.txt"));

                if (step < -31 || step > 31 || step == 0) Console.WriteLine("ошибка! В файле храниться значение, которое не может быть шагом для новой позиции букв");
                else
                {
                    char[] message;
                    string m = "";
                    bool answer;
                    
                    answer = Answer();
                    if (answer == true)
                    {
                        Console.WriteLine("введите сообщение для зашифровки");
                        m = Console.ReadLine();
                        message = m.ToCharArray();
                        string error = EnglishWords(message);
                        if (error == "") Console.WriteLine(Zashifr(message, step));
                        else Console.WriteLine(error);
                    }
                    else
                    {
                        Console.WriteLine("введите сообщение для расшифровки");
                        m = Console.ReadLine();
                        message = m.ToCharArray();
                        string error = EnglishWords(message);
                        if (error == "") Console.WriteLine(Zashifr(message, -(step)));
                        else Console.WriteLine(error);
                    }
                }
            }
            catch
            {
                Console.WriteLine("ошибка! В файле храниться значение, которое не может быть шагом для новой позиции букв");
                
            }
            Console.ReadKey();
        }
        static string EnglishWords(char[] message)
        {
            string mess = "";
            for(int i = 0; i <message.Length; i++)
            {
                if (((message[i] >= 'a') && (message[i] <= 'z')) || ((message[i] >= 'A') && (message[i] <= 'Z'))) mess = "в строке есть нерусские буквы"; 
            }
            return mess;
        }
        static Boolean Answer()
        {
            bool answer;
            while (true)
            {
                Console.WriteLine("выберите:\n1. зашифровать \n2. расшифровать");
                string answ = Console.ReadLine();
                if (answ == "1") { answer = true; break; }
                else
                {
                    if (answ == "2") { answer = false; break; }
                }
            }
            return answer;
        }
        static string Zashifr(char[] message, int step)
        {
            int nomer; 
            int d; 
            string s;
            int j;
            char[] alfavit = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };

            for (int i = 0; i < message.Length; i++)
            {
                
                for (j = 0; j < alfavit.Length; j++)
                {
                    if (message[i] == alfavit[j])
                    {
                        break;
                    }
                }

                if (j != 33) 
                {
                    nomer = j; 
                    d = nomer + step;

                    if (d > 32)
                    {
                        d = d - 33;
                    }
                    if (d < 0)
                    {
                        d = d + 33; 
                    }

                    message[i] = alfavit[d]; 
                }
            }

            s = new string(message); 
            
            return s;
        }
    }
}
