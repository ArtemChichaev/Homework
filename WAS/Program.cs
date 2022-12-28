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
            {4,"Удалить"},
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
                case "Добавить":
                    var good = GetNewGood();
                    AddGood(good);
                    break;
                default:
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
            int number = 0;
            while (!int.TryParse(Console.ReadLine(), out number) || number < startNumber || number > endNumber)
            {
                Console.WriteLine("Данные введены некорректно. Попробуйте снова.");
            }
            return number;
        }
        private static void AddGood(Goods good)
        {
            if (good == null)
            {
                return;
            }
            if (GoodsDict.Contains(good.Id))
            {
                Console.WriteLine("Товар с таким Id уже существует.");
                return;
            GoodsDict.Add(good.Id, good);
        }
        private static Goods GetNewGood()
        {
            Console.WriteLine("Введите Id товара.");
            int id = Console.ReadLine();
            Console.WriteLine("Введите наименование товара.");
            var name = Console.ReadLine();
            var description = Console.ReadLine();
            var category = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            var gds = new Goods(0, name, description, category, quantity);
            return gds;
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