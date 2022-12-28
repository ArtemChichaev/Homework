using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        static Dictionary<int, string> ToDoItemsDict = new()
                {
                    {1, "Уборка" },
                    {2, "Готовка" },
                    {3, "Шопинг" },
                    {4, "Отдых" }
                };
        static void Main(string[] args)
        {
            Console.WriteLine("Это Ваш список дел!");
            Console.WriteLine("Здесь Вы можете отмечать выполнение Ваших дел, добавлять и удалять дела.");
            Console.WriteLine();
            ActionList();
            ShowList();
            string userChoise = Console.ReadLine();
            string exame = "+-=";
            while (userChoise != "*")
            {
                while (!exame.Contains(userChoise))
                {
                    Console.WriteLine("Данные введены некорректно. Попробуйте снова.");
                    Console.ReadLine();
                }
                switch (userChoise)
                {
                    case "+":
                        Console.WriteLine("Введите дейтсвие, которое хотите добавить в список.");
                        var getDo = Console.ReadLine().ToLower();
                        ToDoItemsDict.Add(ToDoItemsDict.Count + 1, getDo);
                        ShowList();
                        break;
                    case "-":
                        Console.WriteLine("Введите номер действия, которое хотите удалить из списка.");
                        int numberDel;
                        while (!int.TryParse(Console.ReadLine(), out numberDel) || numberDel < 1 || numberDel > ToDoItemsDict.Count)
                        {
                            Console.WriteLine("Данные введены некорректно. Попробуйте снова.");
                        }
                        ToDoItemsDict.Remove(numberDel);
                        ShowList();
                        break;
                    case "=":
                        Console.WriteLine("Введите номер действия, которому хотите добавить отметку выполнения.");
                        int numberDone;
                        while (!int.TryParse(Console.ReadLine(), out numberDone) || numberDone < 1 || numberDone > ToDoItemsDict.Count)
                        {
                            Console.WriteLine("Данные введены некорректно. Попробуйте снова.");
                        }
                        ToDoItemsDict[numberDone] = ToDoItemsDict[numberDone] + " сделано!";
                        ShowList();
                        break;
                }
                Console.Clear();
                ActionList();
                ShowList();
                userChoise = Console.ReadLine();
            }
            Console.Clear();
            Console.WriteLine("Работа завершена!");
        }
        static void ActionList()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("+ - добавить (введите номер для списка, введите дело);");
            Console.WriteLine("- - удалить (введите номер дела).");
            Console.WriteLine("= - выполнено (введите номер дела).");
            Console.WriteLine("* - завершить работу со списком.");
            Console.WriteLine();
            DateTime dateTime = DateTime.Now;
            Console.WriteLine(dateTime);
            Console.WriteLine();
        }
        static void ShowList()
        {
            foreach (var item in ToDoItemsDict)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }
    }
}