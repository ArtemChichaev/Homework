using System;

namespace ToDo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Это Ваш список дел!");
            Console.WriteLine("Здесь Вы можете отмечать выполнение Ваших дел, добавлять и удалять дела.");
            void Info()
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("+ - добавить (введите номер для списка, введите дело);");
                Console.WriteLine("- - удалить (введите номер дела).");
                Console.WriteLine("= - выполнено (введите номер дела).");
                Console.WriteLine("* - завершить работу со списком.");
                DateTime dateTime = DateTime.Parse("12.12.2022");
                Console.WriteLine(dateTime.ToLongDateString());
            }
            Info();
            var listDo = new Dictionary<int, string>()
                {
                    {1, "Уборка" },
                    {2, "Готовка" },
                    {3, "Шопинг" },
                    {4, "Отдых" }
                };
            void ShowList()
            {
                foreach (var item in listDo)
                {
                    Console.WriteLine(item.Key + " " + item.Value);
                }
            }
            ShowList();
            string UserChoise = Console.ReadLine();
            string Exame = "+-=";
            while (UserChoise != "*")
            {
                while (!Exame.Contains(UserChoise))
                {
                    Console.WriteLine("Данные введены некорректно. Попробуйте снова.");
                }
                switch (UserChoise)
                {
                    case "+":
                        Console.WriteLine("Введите дейтсвие, которое хотите добавить в список.");
                        var GetDo = Console.ReadLine().ToLower();
                        listDo.Add(listDo.Count + 1, GetDo);
                        ShowList();
                        break;
                    case "-":
                        Console.WriteLine("Введите номер действия, которое хотите удалить из списка.");
                        int NumberDel;
                        while (!int.TryParse(Console.ReadLine(), out NumberDel) || NumberDel < 1 || NumberDel > listDo.Count)
                        {
                            Console.WriteLine("Данные введены некорректно. Попробуйте снова.");
                        }
                        listDo.Remove(NumberDel);
                        ShowList();
                        break;
                    case "=":
                        Console.WriteLine("Введите номер действия, которому хотите добавить отметку выполнения.");
                        int NumberDone;
                        while (!int.TryParse(Console.ReadLine(), out NumberDone) || NumberDone < 1 || NumberDone > listDo.Count)
                        {
                            Console.WriteLine("Данные введены некорректно. Попробуйте снова.");
                        }
                        listDo[NumberDone] = listDo[NumberDone] + " сделано!";
                        ShowList();
                        break;
                }
                Console.Clear();
                Info();
                ShowList();
                UserChoise = Console.ReadLine();
            }
            Console.Clear();
            Console.WriteLine("Работа завершена!");
        }
    }
}