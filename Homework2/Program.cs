double reward = 0.5;
Console.WriteLine("Викторина \"Кто хочет стать програмистом?\"\r\n" +
    "Нужно ответить на несколько вопросов. " +
    "За каждый правильный ответ вы получаете " + reward + " баллов\r\n" +
    "Постарайтесь набрать максимуму баллов\r\nНажмите enter чтобы начать");
double score = 0;
int answer = 0;
int win = 0;
Console.ReadLine();
Console.Clear();
Console.WriteLine("Вопрос #1");
Console.WriteLine("Кого принято считать первым программистом?");
Console.WriteLine("1 - Ада Лавлейс");
Console.WriteLine("2 - Элфрид Аннун");
Console.WriteLine("3 - Астор Карр");
Console.WriteLine("4 - Кристоф Александер");
while (!int.TryParse(Console.ReadLine(), out answer) || answer < 1 || answer > 4)
{
    Console.WriteLine("Такого ответа нет");
}

if (answer == 1)
{
    score = score + reward;
    win = win + 1;

}
Console.Clear();
Console.WriteLine("Вопрос #2");
Console.WriteLine("Какого языка программирования не существует?");
Console.WriteLine("1 - Go");
Console.WriteLine("2 - Perl");
Console.WriteLine("3 - C+");
Console.WriteLine("4 - Haskel");
Console.WriteLine("5 - F#");
while (!int.TryParse(Console.ReadLine(), out answer) || answer < 1 || answer > 4)
{
    Console.WriteLine("Такого ответа нет");
}

if (answer == 3)
{
    score = score + reward;
    win = win + 1;

}
Console.Clear();
Console.WriteLine("Вопрос #3");
Console.WriteLine("Как называется алгоритм, который на каком-либо шаге обращается сам к себе?");
Console.WriteLine("1 - Циклическим");
Console.WriteLine("2 - Вспомогательным");
Console.WriteLine("3 - Самоссылащимся");
Console.WriteLine("4 - Рекурсивным");
while (!int.TryParse(Console.ReadLine(), out answer) || answer < 1 || answer > 4)
{
    Console.WriteLine("Такого ответа нет");
}

if (answer == 4)
{
    score = score + reward;
    win = win + 1;

}
Console.Clear();
Console.WriteLine("Викторина окончена.");
Console.WriteLine("3 вопроса, правильных ответов - " + win);
Console.WriteLine("Набрано " + score + " баллов");