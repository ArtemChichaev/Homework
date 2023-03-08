namespace Event
{
    internal class Program
    {
        public static void Delete()
        {
            Console.Clear();
            Text.Clear();
        }
        static List<char> Text = new();
        public static event Action DeleteEvent;
        static void Main(string[] args)
        {
            DeleteEvent += Delete;
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey();
                if (cki.Key != ConsoleKey.Delete)
                {
                    Text.Add(cki.KeyChar);
                    Console.SetCursorPosition(0, 0);
                    for (int i = 0; i < Text.Count; i++)
                    {
                        Console.Write(Text[i]);
                    }
                    Console.SetCursorPosition(0, 1);
                }
                else
                {
                    DeleteEvent?.Invoke();
                }
            }
        }
    }
}