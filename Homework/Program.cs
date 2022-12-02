Console.WriteLine("Вас приветсвует УГАДАЙКА! Попробуйте угадать число (число положительное, от 1 до 500), которое загадала программа.");
int secret = new Random().Next(1, 500);
int userNumber;
while (!int.TryParse(Console.ReadLine(), out userNumber) || userNumber <= 0 || userNumber > 500 || userNumber != secret)
{
    Console.WriteLine("Данные введены некоректно или введенное Вами число не совпадает с числом программы! Попробуйте снова");
}
Console.WriteLine("Поздравляем! Вы угадали число" + userNumber);