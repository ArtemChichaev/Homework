namespace Converter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветсивует конвертер валют! Пожалуйста, выберите нужный Вам обменный курс (введите цифру):");
            Dictionary<int, string> list = new Dictionary<int, string>()
            {
                {1, "Рубли -> Доллары" },
                {2, "Доллары -> Рубли" },
                {3, "Рубли -> Евро" },
                {4, "Евро -> Рубли" },
                {5, "Евро -> Доллары" },
                {6, "Доллары -> Евро" }
            };
            foreach (var word in list)
            {
                Console.WriteLine(word.Key + " " + word.Value);
            }
            int userChoise;
            while (!int.TryParse(Console.ReadLine(), out userChoise) || userChoise < 1 || userChoise > list.Count)
            {
                Console.WriteLine("Данные введены некорректно. Попробуйте снова.");
            }
            Console.WriteLine("Введите сумму, которую хотите cконвертировать (данные вводятся цифрами):");
            double userMoney;
            while (!double.TryParse(Console.ReadLine(), out userMoney))
            {
                Console.WriteLine("Данные введены некорректно. Попробуйте снова.");
            }
            if (userChoise == 1)
            {
                Console.WriteLine(userMoney + " Рублей -> " + userMoney / 62.9 + " Долларов.");
            }
            if (userChoise == 2)
            {
                Console.WriteLine(userMoney + " Долларов -> " + userMoney * 62.9 + " Рублей.");
            }
            if (userChoise == 3)
            {
                Console.WriteLine(userMoney + " Рублей -> " + userMoney / 66.1 + " Евро.");
            }
            if (userChoise == 4)
            {
                Console.WriteLine(userMoney + " Евро -> " + userMoney * 66.1 + " Рублей.");
            }
            if (userChoise == 5)
            {
                Console.WriteLine(userMoney + " Евро -> " + userMoney * 1.05 + " Долларов.");
            }
            if (userChoise == 6)
            {
                Console.WriteLine(userMoney + " Долларов -> " + userMoney / 1.05 + " Евро.");
            }
        }
    }
}