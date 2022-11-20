Console.WriteLine("Вас приветсвует УГАДАЙКА! Попробуйте угадать число (число положительное, от 1 до 500), которое загадала программа.");
int secret = new Random().Next(1, 500);
int UserNumber; // названия переменных пишем в camelCase, загугли

// кривое форматированмие, нажми Ctrl + K + D
    while (!int.TryParse(Console.ReadLine(), out UserNumber) || UserNumber <= 0 || UserNumber > 500 || UserNumber != secret)
{
    Console.WriteLine("Данные введены некоректно или введенное Вами число не совпадает с числом программы! Попробуйте снова");
}

Console.WriteLine( "Поздравляем! Вы угадали число" + UserNumber);
// лишняя пустая строка
// лишняя пустая строка
// лишняя пустая строка