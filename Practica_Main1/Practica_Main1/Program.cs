using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Practica_Main1
{

    public class CounterSingleton
    {
        public static CounterSingleton instance;

        private int counter;

        private CounterSingleton()
        {
            counter = 0;
            Console.WriteLine("Счетчик посещения создан");
        }

        public static CounterSingleton GetInstance()
        {
            if (instance == null)
                instance = new CounterSingleton();
            return instance;
        }

        public void ChangeCounter()
        {
            counter++;
            Console.WriteLine($"Посещение зарегестрировано. Всего посещений: {counter}");
        }

        public void ResetCounter()
        {
            counter = 0;
            Console.WriteLine($"Счетчик сброшен");
        }
    }
    public class ApplicationSettingsManager
    {
        private string filePath = "settings.json";
        private Dictionary<string, string> storageBase;

        private static ApplicationSettingsManager instance;

        private ApplicationSettingsManager()
        {
            storageBase = new Dictionary<string, string>();
            LoadSettings();
        }

        public static ApplicationSettingsManager GetInstance()
        {
            if (instance == null)
                instance = new ApplicationSettingsManager();
            return instance;
        }

        public void SaveSettings()
        {
            string json = JsonSerializer.Serialize(storageBase);
            File.WriteAllText(filePath, json);
        }

        public void LoadSettings()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);

                storageBase = JsonSerializer.Deserialize<Dictionary<string, string>>(json)
                              ?? new Dictionary<string, string>();
            }
        }
        public void SetSetting(string key, string value)
        {
            

            if (storageBase.ContainsKey(key) == true) // сразу идет проверка, есть ли такая настройка
            {
                storageBase[key] = value; // если есть, то значит user хочет обновить. меняем значение
                Console.WriteLine("Настройка обновлена! ( づ￣ ³￣ )づ");
            }
            else
            {
                storageBase.Add(key, value);
                Console.WriteLine($"Настройка добавлена! Всего настроек: {storageBase.Count()} ( ＾◡＾)っ ♡");
            }
            SaveSettings();

            Console.WriteLine(" ");
        }

        public string GetSetting(string key)
        {
            Console.WriteLine($"Значение твоей настройки: {storageBase[key]}. Всего настроек: {storageBase.Count()} (✧ᗜ✧)");
            Console.WriteLine(" ");
            return storageBase[key];
        }

        public void ShowAllSettings()
        {
            if (storageBase.Count > 0)
            { 
                foreach (var (key, value) in storageBase)
                {
                    Console.WriteLine($"| {key}: {value} |");
                }
                Console.WriteLine("Все настройки выведены! (๑ >ᴗ< ๑)");
            }
            else
            {
                Console.WriteLine("Пока нет никаких настроек! ╮ (. ❛ ᴗ ❛.) ╭");
            }
            Console.WriteLine(" ");
        }

        public void ClearOneSettings(string key)
        {
            if (storageBase.ContainsKey(key) == true)
            {
                storageBase.Remove(key);
                SaveSettings();

                Console.WriteLine("Настройка удалена!");
            }
            else
            {
                Console.WriteLine("Такой настройки нет! (ง'̀-'́)ง");
            }
            Console.WriteLine(" ");
        }

        public void ClearSettings()
        {
            if (storageBase.Count > 0)
            {
                storageBase.Clear();
                SaveSettings();

                Console.WriteLine("Настройки очищены..(╥_╥)");
            }
            else
            {
                Console.WriteLine("Пока что не было добавлено ни одной настройки..¯\\_(ツ)_/¯");
            }
            Console.WriteLine(" ");
        }

    }
    internal class Program
    {
        //CounterSingleton s = CounterSingleton.GetInstance();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            ApplicationSettingsManager s1 = ApplicationSettingsManager.GetInstance();
            ApplicationSettingsManager s2 = ApplicationSettingsManager.GetInstance();

            Console.WriteLine($"Обращения имеет один объект: {ReferenceEquals(s1, s2)}");

            Console.WriteLine($"Хеш-код s1: {s1.GetHashCode()}");
            Console.WriteLine($"Хеш-код s2: {s2.GetHashCode()}");

            /*bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("1. Зарегестрировать");
                Console.WriteLine("2. Сбросить счетчик");
                Console.WriteLine("3. Выйти");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CounterSingleton.GetInstance().ChangeCounter();
                        break;
                    case "2":
                        CounterSingleton.GetInstance().ResetCounter();
                        break;
                    case "3":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Неправильный ввод!");
                        break;
                }
            }*/

            Console.WriteLine("Нормайкин Руслан");
            Console.WriteLine("Учебная группа ИП-42");
            Console.WriteLine("ПР №1: Паттерн Одиночка");
            Console.WriteLine("Демонстрация работы менеджера настроек");

            Console.WriteLine(" ");
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("ʕ •ᴥ•ʔ МЕНЮ УПРАВЛЕНИЯ НАСТРОЙКАМИ ʕ •ᴥ•ʔ");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine(" ");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("| 1. Показать все настройки |(• ◡•)|    |");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("| 2. Добавить/Обновить настройку (❍ᴥ❍ʋ) |");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("| 3. Получить значение настройки ʕ •́؈•̀) |");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("| 4. Удалить настройку  (o^-^o)         |");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("| 5. Очистить все настройки (㇏(•̀ᵥᵥ•́)ノ)|");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("| 6. Выход из программы                 |");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine(" ");

                string input = Console.ReadLine();


                switch (input)
                {
                    case "1":
                        ApplicationSettingsManager.GetInstance().ShowAllSettings();
                        break;
                    case "2":
                        Console.Write("Введите название настройки (ключ): ");
                        string key = Console.ReadLine();
                        Console.Write("Введите значение настройки: ");
                        string value = Console.ReadLine();
                        ApplicationSettingsManager.GetInstance().SetSetting(key, value);
                        break;
                    case "3":
                        Console.Write("Введите название настройки (ключ): ");
                        string key_for_show = Console.ReadLine();
                        ApplicationSettingsManager.GetInstance().GetSetting(key_for_show);
                        break;
                    case "4":
                        Console.Write("Введите название настройки (ключ): ");
                        string key_for_clear = Console.ReadLine();
                        ApplicationSettingsManager.GetInstance().ClearOneSettings(key_for_clear);
                        break;

                    case "5":
                        ApplicationSettingsManager.GetInstance().ClearSettings();
                        break;
                    case "6":
                            isRunning = false;
                            break;
                    default:
                        Console.WriteLine("Неправильный ввод!");
                        break;
                }
            }

            
        }
    }
}
