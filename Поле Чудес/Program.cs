//int ReadNumber(string message, string errorMessage = "Такого числа нет.")
//{
//    int p = 0;
//    Console.WriteLine(message);
//    while (!int.TryParse(Console.ReadLine(), out p))
//    {
//        Console.WriteLine(errorMessage);
//    }
//    return p;
//}
//var age = ReadNumber("Введите ваш возраст", "Возраст введен неверно");
//var UserNumber = ReadNumber("Введите любимое число");
//Console.WriteLine("Ваш возраст - " + age);
//Console.WriteLine("Ваше любимое число - " + UserNumber);
Console.WriteLine("\"Здравствуйте. Это игра 'Поле чудес'\"\r\n" +
    "Сектор приз на барабане! Внимание вопрос\r\n" +
    "Автомат для превращения кофе в код - это ... ?\"\r\n" +
    "Если знаете ответ - введите слово целиком. Или введите букву и нажмите enter\r\n");
string answer = "программист";
string[] finallyAnswer = new string[answer.Length];
string inputUser = default;
for (int i = 0; i < finallyAnswer.Length; i++)
{
    finallyAnswer[i] = "*";
}

while (inputUser != answer)
{
    inputUser = Console.ReadLine().ToLower().Trim();

    if (!finallyAnswer.Contains("*") || inputUser == "программист")
    {
        answer = inputUser;
        continue;
    }
    if (!answer.Contains(inputUser) && inputUser.Length == 1)
    {
        Console.WriteLine("\"Нет такой буквы.\"\r\n" +
          "Если знаете ответ - введите слово целиком. Или введите букву и нажмите enter\r\n");
    }
    else if (inputUser.Length > 1)
    {
        Console.WriteLine("\"Не угадали.\"\r\n" +
          "Если знаете ответ - введите слово целиком. Или введите букву и нажмите enter\r\n");
    }
    else if (finallyAnswer.Contains(inputUser))
    {
        Console.WriteLine("\"Эта буква уже открыта\"\r\n" +
          "Если знаете ответ - введите слово целиком. Или введите букву и нажмите enter\r\n");
    }
    else if (inputUser.Length == 0)
    {
        Console.WriteLine("Если знаете ответ - введите слово целиком. Или введите букву и нажмите enter");
        continue;
    }
    //if (!answer.Contains(inputUser) && inputUser.Length == 1)
    //{
    //    Console.WriteLine("\"Нет такой буквы.\"\r\n" +
    //       "Если знаете ответ - введите слово целиком. Или введите букву и нажмите enter\r\n");
    //}
    //if (inputUser.Length > 1)
    //{
    //    Console.WriteLine("\"Не угадали.\"\r\n" +
    //       "Если знаете ответ - введите слово целиком. Или введите букву и нажмите enter\r\n");
    //}
    //if (finallyAnswer.Contains(inputUser))
    //{
    //    Console.WriteLine("\"Эта буква уже открыта\"\r\n" +
    //       "Если знаете ответ - введите слово целиком. Или введите букву и нажмите enter\r\n");
    //}
    //if (inputUser.Length == 0)
    //{
    //    Console.WriteLine("Если знаете ответ - введите слово целиком. Или введите букву и нажмите enter");
    //}
    if (answer.Contains(inputUser))
    {
        for (int j = 0; j < answer.Length; j++)
        {
            string word = answer[j].ToString();
            if (word.Contains(inputUser))
            {
                finallyAnswer[j] = word;
            }
            Console.Write(finallyAnswer[j]);
        }
    }
}
Console.WriteLine("И вы угадали!!!! Это 'Программист'");