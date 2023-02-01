namespace MailBox
{
    internal class Program
    {
        static Dictionary<int, Message> InBox = new()
        {
            {1, new Message("Собрание", "Уважаемые коллеги! Сегодня в 14:00 собрани в конференц зале!", DateTime.Now, "petrova@job.com")},
            {2, new Message("Оповещение!", "Сегодня в 12:00 будет проходить наладка сети!", DateTime.Now, "petrova@job.com")},
        };
        static Dictionary<int, Message> OutBox = new()
        {
            {1, new Message("Заявка на закупку оборудования.", "День добрый! Одобрено.", DateTime.Now, "ivanov@job.com")},
        };
        static Dictionary<int, Message> Spam = new()
        {
            {1, new Message("Выгодные цены!", "Покупайте наши пылесосы со скидкой 78%!!!", DateTime.Now, "spam@job.com")},
        };
        static Dictionary<int, Message> Trash = new()
        {
            {1, new Message("Выгодные цены!", "Покупайте наши трусы со скидкой 77%!!!", DateTime.Now, "spam@job.com")},
        };
        static Dictionary<int, string> AddressBook = new()
        {
            {1, "Иванов Иван Иванович ivanov@job.com" },
            {2, "Петрова Ольга Петровна petrova@job.com" },
        };
        static Dictionary<int, string> ActionUser = new()
        {
            {1, "Показать входящие" },
            {2, "Показать отправленные" },
            {3, "Открыть корзину" },
            {4, "Показать СПАМ" },
            {5, "Открыть адресную книгу" },
        };
        static Dictionary<int, string> ActionInBox = new()
        {
            {1, "Открыть письмо" },
            {2, "Удалить письмо" },
            {3, "Пометить, как СПАМ" },
        };
        static Dictionary<int, string> ActionOutBox = new()
        {
            {1, "Открыть письмо" },
            {2, "Удалить письмо" },
            {3, "Написать письмо" },
        };
        static Dictionary<int, string> ActionSpam = new()
        {
            {1, "Открыть письмо" },
            {2, "Удалить письмо" },
        };
        static Dictionary<int, string> ActionTrash = new()
        {
            {1, "Открыть письмо" },
            {2, "Очистить корзину" },
        };
        static Dictionary<int, string> ActionWithAddressBook = new()
        {
            {1, "Добавить адресата" },
            {2, "Удалить адресата" },
        };
        static void Main(string[] args)
        {
            Console.WriteLine("Добрый день! Это Ваш почтовый ящик!");
            Console.WriteLine("Выберите действие, которое хотите выполнить:");
            ShowDictionary(ActionUser);

            int userChoise;
            while (!int.TryParse(Console.ReadLine(), out userChoise) || !ActionUser.ContainsKey(userChoise))
            {
                Console.Clear();
                Console.WriteLine("Такого действия нет. Попробуйте снова.");
                Console.ReadLine();
            }
            switch (userChoise)
            {
                case 1:
                    Console.WriteLine("Входящие:");
                    if (InBox == default)
                    {
                        Console.WriteLine("Папка пустая!");
                    }
                    else
                    {
                        ShowMessage(InBox);
                        Console.WriteLine("Выберите действие (введите цифру):");
                        ShowDictionary(ActionInBox);
                        int userChoiseInBox;
                        while (!int.TryParse(Console.ReadLine(), out userChoiseInBox) || userChoiseInBox < 1 || userChoiseInBox > InBox.Count)
                        {
                            Console.WriteLine("Данные введены некорректно. Попробуйте снова.");
                            Console.ReadLine();
                        }
                        break;
                        switch (userChoiseInBox)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Выберите сообщение, которое хотите просмотреть (введите его номер):");
                                ShowDictionary(ActionInBox);
                                int numberShow = 0;
                                while (!int.TryParse(Console.ReadLine(), out numberShow) || !InBox.ContainsKey(numberShow))
                                {
                                    Console.WriteLine("Такого сообщения нет. Попробуйте снова.");
                                    Console.ReadLine();
                                }
                                var choiseShowInInBox = InBox[numberShow];
                                Console.WriteLine(InBox[numberShow].AddressName + " " + InBox[numberShow].Date + " " + InBox[numberShow].Theme);
                                Console.WriteLine(InBox[numberShow].Content);
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Выберите сообщение, которое хотите удалить (введите его номер):");
                                ShowMessage(InBox);
                                int numberDel = 0;
                                while (!int.TryParse(Console.ReadLine(), out numberDel) || !InBox.ContainsKey(numberDel))
                                {
                                    Console.WriteLine("Такого сообщения нет. Попробуйте снова.");
                                    Console.ReadLine();
                                }
                                int n = GenerationId(Trash);
                                Trash.Add(n, InBox[numberDel]);
                                InBox.Remove(numberDel);
                                Console.WriteLine("Сообщение удалено (перемещено в корзину).");
                                ShowMessage(InBox);
                                break;
                            case 3:
                                Console.Clear();
                                Console.WriteLine("Выберите сообщение, которое хотите пометить, как СПАМ (введите его номер):");
                                ShowMessage(InBox);
                                int numberSpam = 0;
                                while (!int.TryParse(Console.ReadLine(), out numberSpam) || !InBox.ContainsKey(numberSpam))
                                {
                                    Console.WriteLine("Такого сообщения нет. Попробуйте снова.");
                                    Console.ReadLine();
                                }
                                Trash.Add(n, InBox[numberSpam]);
                                InBox.Remove(numberSpam);
                                ShowMessage(InBox);
                                Console.WriteLine("Сообщение помечено, как СПАМ (перемещено в корзину).");
                                break;
                        }
                    }
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Отправленные:");
                    if (OutBox == default)
                    {
                        Console.WriteLine("Папка пустая!");
                    }
                    else
                    {
                        ShowMessage(OutBox);
                        Console.WriteLine("Выберите действие (введите цифру):");
                        ShowDictionary(ActionOutBox);
                        int userChoiseOutBox = 0;
                        while (!int.TryParse(Console.ReadLine(), out userChoiseOutBox) || userChoiseOutBox < 1 || userChoiseOutBox > OutBox.Count)
                        {
                            Console.WriteLine("Данные введены некорректно. Попробуйте снова.");
                            Console.ReadLine();
                        }
                        break;
                        switch (userChoiseOutBox)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Выберите сообщение, которое хотите просмотреть (введите его номер):");
                                ShowMessage(OutBox);
                                int numberShow = 0;
                                while (!int.TryParse(Console.ReadLine(), out numberShow) || !OutBox.ContainsKey(numberShow))
                                {
                                    Console.WriteLine("Такого сообщения нет. Попробуйте снова.");
                                    Console.ReadLine();
                                }
                                var choiseShowInOutBox = OutBox[numberShow];
                                Console.WriteLine(OutBox[numberShow].AddressName + " " + OutBox[numberShow].Date + " " + OutBox[numberShow].Theme);
                                Console.WriteLine(OutBox[numberShow].Content);
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Выберите сообщение, которое хотите удалить (введите его номер):");
                                ShowMessage(OutBox);
                                int numberDel = 0;
                                while (!int.TryParse(Console.ReadLine(), out numberDel) || !OutBox.ContainsKey(numberDel))
                                {
                                    Console.WriteLine("Такого сообщения нет. Попробуйте снова.");
                                    Console.ReadLine();
                                }
                                int n = GenerationId(Trash);
                                Trash.Add(n, OutBox[numberDel]);
                                OutBox.Remove(numberDel);
                                Console.WriteLine("Сообщение удалено (перемещено в корзину).");
                                ShowMessage(OutBox);
                                break;
                            case 3:
                                Console.Clear();
                                Console.WriteLine("Введите тему, адресата и содержание сообщения:");
                                CreateMessage();
                                Console.WriteLine("Сообщение отправленно!");
                                break;
                        }
                    }
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("СПАМ:");
                    if (Spam == default)
                    {
                        Console.WriteLine("Папка пустая!");
                    }
                    else
                    {
                        ShowMessage(Spam);
                        Console.WriteLine("Выберите действие (введите цифру):");
                        ShowDictionary(ActionSpam);
                        int userChoiseSpam = 0;
                        while (!int.TryParse(Console.ReadLine(), out userChoiseSpam) || userChoiseSpam < 1 || userChoiseSpam > Spam.Count)
                        {
                            Console.WriteLine("Данные введены некорректно. Попробуйте снова.");
                            Console.ReadLine();
                        }
                        break;
                        switch (userChoiseSpam)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Выберите сообщение, которое хотите просмотреть (введите его номер):");
                                ShowMessage(Spam);
                                int numberShow = 0;
                                while (!int.TryParse(Console.ReadLine(), out numberShow) || !Spam.ContainsKey(numberShow))
                                {
                                    Console.WriteLine("Такого сообщения нет. Попробуйте снова.");
                                    Console.ReadLine();
                                }
                                var choiseShowInSpam = Spam[numberShow];
                                Console.WriteLine(Spam[numberShow].AddressName + " " + Spam[numberShow].Date + " " + Spam[numberShow].Theme);
                                Console.WriteLine(Spam[numberShow].Content);
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Выберите сообщение, которое хотите удалить (введите его номер):");
                                ShowMessage(Spam);
                                int numberDel = 0;
                                while (!int.TryParse(Console.ReadLine(), out numberDel) || !Spam.ContainsKey(numberDel))
                                {
                                    Console.WriteLine("Такого сообщения нет. Попробуйте снова.");
                                    Console.ReadLine();
                                }
                                int n = GenerationId(Trash);
                                Trash.Add(n, Spam[numberDel]);
                                Spam.Remove(numberDel);
                                Console.WriteLine("Сообщение удалено (перемещено в корзину).");
                                ShowMessage(Spam);
                                break;
                        }
                    }
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Корзина:");
                    if (Trash == default)
                    {
                        Console.WriteLine("Корзина пустая!");
                    }
                    else
                    {
                        ShowMessage(Trash);
                        Console.WriteLine("Выберите действие (введите цифру):");
                        ShowDictionary(ActionTrash);
                        int userChoiseTrash = 0;
                        while (!int.TryParse(Console.ReadLine(), out userChoiseTrash) || userChoiseTrash < 1 || userChoiseTrash > Trash.Count)
                        {
                            Console.WriteLine("Данные введены некорректно. Попробуйте снова.");
                            Console.ReadLine();
                        }
                        break;
                        switch (userChoiseTrash)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Выберите сообщение, которое хотите просмотреть (введите его номер):");
                                ShowMessage(Spam);
                                int numberShow = 0;
                                while (!int.TryParse(Console.ReadLine(), out numberShow) || !Trash.ContainsKey(numberShow))
                                {
                                    Console.WriteLine("Такого сообщения нет. Попробуйте снова.");
                                    Console.ReadLine();
                                }
                                var choiseShowInTrash = InBox[numberShow];
                                Console.WriteLine(Trash[numberShow].AddressName + " " + Trash[numberShow].Date + " " + Trash[numberShow].Theme);
                                Console.WriteLine(Trash[numberShow].Content);
                                break;
                            case 2:
                                Console.Clear();
                                Spam.Clear();
                                Console.WriteLine("Корзина пустая!");
                        }
                    }
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Ваша книга контактов:");
                    if (AddressBook == default)
                    {
                        Console.WriteLine("Книга контактов пустая!");
                    }
                    else
                    {
                        ShowDictionary(AddressBook);
                        Console.WriteLine("Выберите действие (введите цифру):");
                        ShowDictionary(ActionWithAddressBook);
                        int userChoiseAddressBook = 0;
                        while (!int.TryParse(Console.ReadLine(), out userChoiseAddressBook) || userChoiseAddressBook < 1 || userChoiseAddressBook > AddressBook.Count)
                        {
                            Console.WriteLine("Данные введены некорректно. Попробуйте снова.");
                            Console.ReadLine();
                        }
                        break;
                        switch (userChoiseAddressBook)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Введите данные контакта (ФИО и электронный адрес):");
                                int n = GenerationIdAddressBook();
                                AddressBook.Add(n, Console.ReadLine());
                                ShowDictionary(AddressBook);
                                Console.WriteLine("Контакт добавлен.");
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Выберите контакт, который хотите удалить (введите цифру):");
                                int numberDel = 0;
                                while (!int.TryParse(Console.ReadLine(), out numberDel) || !AddressBook.ContainsKey(numberDel))
                                {
                                    Console.WriteLine("Такого сообщения нет. Попробуйте снова.");
                                    Console.ReadLine();
                                }
                                AddressBook.Remove(numberDel);
                                ShowDictionary(AddressBook);
                                Console.WriteLine("Контакт удалён.");
                        }
                    }
                    break;
            }
            static void ShowDictionary(Dictionary<int, string> dic)
            {
                foreach (var item in dic)
                {
                    Console.WriteLine(item.Key + " " + item.Value);
                }
            }
            static void ShowMessage(Dictionary<int, Message> dic)
            {
                foreach (var item in dic)
                {
                    Console.WriteLine(item.Key + " " + item.Value.Theme + " " + item.Value.Date + " " + item.Value.AddressName);
                }
            }
            static int GenerationIdAddressBook()
            {
                int key = 1;
                while (AddressBook.ContainsKey(key))
                {
                    key++;
                }
                return key;
            }
            static int GenerationId(Dictionary<int, Message> dic)
            {
                int key = 1;
                while (dic.ContainsKey(key))
                {
                    key++;
                }
                return key;
            }
            static void CreateMessage()
            {
                string theme = InputString("Введите тему:");
                string adressName = InputString("Введите адресата:");
                string content = InputString("Введите текст письма:");
                Message newMessage = new Message(theme, content, DateTime.Now, adressName);
                int n = GenerationId(OutBox);
                OutBox.Add(n, newMessage);
                static string InputString(string message)
                {
                    Console.WriteLine(message);
                    string value = Console.ReadLine();
                    while (string.IsNullOrEmpty(value))
                    {
                        Console.WriteLine("Нельзя отправить пустое сообщение!");
                        Console.WriteLine();
                        Console.WriteLine(message);
                        value = Console.ReadLine();
                    }
                    return value;
                }
            }
        }
    }
}