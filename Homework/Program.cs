Console.WriteLine("Вас приветсвует УГАДАЙКА! Попробуйте угадать число (число положительное, от 1 до 500), которое загадала программа.");
int secret = new Random().Next(1, 500);
int UserNumber;
    while (!int.TryParse(Console.ReadLine(), out UserNumber) || UserNumber <= 0 || UserNumber > 500 || UserNumber != secret)
{
    Console.WriteLine("Данные введены некоректно или введенное Вами число не совпадает с числом программы! Попробуйте снова");
}

Console.WriteLine( "Поздравляем! Вы угадали число" + UserNumber);   


