namespace WAS
{
    internal class Program
    {
        static Dictionary<int, Goods> GoodsDict = new();
        static Dictionary<int, string> ActionsWithGoodsDict = new()
        {
            {1,"Поиск товара"},
            {2,"Вывод названия и количества товара"},
            {3,"Добавить"},
            {4,"Удалить"}
        };
        static void Main(string[] args)
        {
            PrintWelcome();
            foreach ((int key, string value) in ActionsWithGoodsDict)
            {
                Console.WriteLine(key + " " + value);
            }
            var actionKey = ActionGoods("Введите номер действия", ActionsWithGoodsDict.Keys.First(), ActionsWithGoodsDict.Keys.Last());
            switch (ActionsWithGoodsDict[actionKey])
            {
                case "Поиск. Введите Id товара":
                    int idFromUser;
                    while (!int.TryParse(Console.ReadLine(), out idFromUser) || Goods.(idFromUser))
                    {
                        Console.WriteLine("");
                    }
                    break;
                case "Вывод количества товара. Введите Id товара":
                    break;
                case "Добавить":
                    var good = GetNewGood();
                    break;
                case "Удалить. Введите Id товара":
                    break;
            }
        }
        private static void PrintWelcome()
        {
            Console.WriteLine("Вас приветствует система складского учета WAS!");
            Console.WriteLine();
        }
        private static int ActionGoods(string message, int startNumber, int endNumber)
        {
            Console.WriteLine(message);
            int number;
            while (!int.TryParse(Console.ReadLine(), out number) || !ActionsWithGoodsDict.ContainsKey(number))
            {
                Console.WriteLine("Данные введены некорректно. Попробуйте снова.");
            }
            return number;
        }
        private static Goods GetNewGood()
        {
            int id;
            if (GoodsDict.Keys.Max() == 0)
            {
                id = 1;
            }
            else
            {
                id = GoodsDict.Keys.Max() + 1;
            }

            Console.WriteLine("Введите наименование товара.");
            string name = GetStringFromUser();
            Console.WriteLine("Введите описание товара.");
            string description = GetStringFromUser();
            Console.WriteLine("Введите категорию товара.");
            string category = GetStringFromUser();
            Console.WriteLine("Введите количество товара (цифрой или числом).");
            int quantity;
            while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
            {
                Console.WriteLine("Данные введены некорректно. Попробуйте снова.");
                Console.ReadLine();
            }
            var gds = new Goods(id, name, description, category, quantity);
        }
        private static string GetStringFromUser()
        {
            var value = Console.ReadLine();
            while (string.IsNullOrEmpty(value))
            {
                Console.WriteLine("Пустого значения быть не может.");
                value = Console.ReadLine();
            }
            return value;
        }
    }
}