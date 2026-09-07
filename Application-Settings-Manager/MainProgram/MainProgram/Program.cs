using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Задача 1. Напишите программу, которая запрашивает у пользователя пароль и проверяет его на правильность.
            // У пользователя есть 3 попытки для ввода правильного пароля.
            // Если пароль введен неверно, программа должна вывести сообщение об ошибке и количество оставшихся попыток.
            // Если пароль введен правильно, программа должна вывести сообщение об успешной авторизации и завершиться.
            /*int count = 3;
            int countForСycle = 3;
            int password = 10034;
            int i = 1;
            
            while ( i <= countForСycle)
            {
                Console.Write($"Введите пароль (осталось {count} попыток): ");
                int input = Convert.ToInt32(Console.ReadLine());

                if (input != password)
                {
                    Console.WriteLine($"Пароль неверный");
                    i++;
                    count--;
                }
                else
                {
                    Console.WriteLine("Пароль верный!");
                    break;
                }
            }*/

            

        }
        static string DeleteVowels(string str)
        {
            string result = "";
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            foreach (char c in str)
            {
                if (!vowels.Contains(c))
                {
                    result += c;
                }
            }
            return result;
        }
        
    }
}
