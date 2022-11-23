string[] pizzas =
{
"Маргарита",
"Маринара",
"Карбонара",
"Неаполетано",
"Эмилиана",
"Сардиния",
"Американо"
};
string[] choise = new string[4];
int answer = 0;
Console.WriteLine("\"Вас приветсвует пиццерия Papa Pizza!\"\r\n" +
    " Только сегодня Вы можете собрать из доступных пицц нашу новую - 4 сезона (4 четвертинки любых пицц в одной):\"\r\n");
foreach (string pizza in pizzas)
{
    Console.WriteLine(pizza);
}
for (int i = 0; i < choise.Length; i++)
{
    while (!int.TryParse(Console.ReadLine(), out answer) || answer < 1 || answer > 7)
    {
        Console.WriteLine("Такого у нас нет! Ознакомьтесь с ассортиментом и повторите попытку.");
    }

    choise[i] = pizzas[answer - 1];
}
Console.WriteLine("Готово! Ваша пицца 4 сезона состоит из пицц:");

foreach (string UserPizza in choise)
{
    Console.WriteLine(UserPizza);
}