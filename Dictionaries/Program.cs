using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckIfDictionariesCreated();

            MyDictionary myDictionary = Start();
            MainMenu(myDictionary);
        }

        static MyDictionary Start()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\tСловари\n");
            Console.ResetColor();

            Console.WriteLine("Выберете какой словарь хотите использовать:\n" +
                "1.Англо-русский\n" +
                "2.Русско-английский");
            int choice;
            MyDictionary myDictionary;
            while (true)
            {
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Введите число");
                    Console.ResetColor();
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        myDictionary = GetDictionary(LanguageType.EnglishRussian);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\tВы выбрали англо-русский словарь\n");
                        Console.ResetColor();
                        break;
                    case 2:
                        myDictionary = GetDictionary(LanguageType.RussianEnglish);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\tВы выбрали русско-английский словарь\n");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Такого пункта меню нет");
                        Console.ResetColor();
                        continue;
                }
                break;
            }

            return myDictionary;
        }

        static void MainMenu(MyDictionary myDictionary)
        {
            while (true)
            {
                Console.WriteLine("Выберете пункт меню:\n" +
                "1.Добавить слово и его перевод(-ы) в словарь\n" +
                "2.Заменить слово или его перевод в словаре\n" +
                "3.Удалить слово или его перевод\n" +
                "4.Найти перевод слова\n" +
                "5.Показать все слова и их переводы\n" +
                "6.Вернуться к выбору типа словаря\n");
                int choice;
                while (true)
                {
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Введите число");
                        Console.ResetColor();
                        continue;
                    }
                    break;
                }

                switch (choice)
                {
                    case 1:
                        #region case1                        
                        Console.WriteLine("\nВыберите: \n" +
                            "1.Добавить один вариант перевода слова \n" +
                            "2.Добавить несколько вариантов перевода\n" +
                            "3.Добавить перводы(-ы) слова к уже существующему слову в словаре\n" +
                            "4.Вернуться в основное меню");
                        int choice2;
                        while (true)
                        {
                            try
                            {
                                choice2 = int.Parse(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Введите число");
                                Console.ResetColor();
                                continue;
                            }

                            try
                            {
                                switch (choice2)
                                {
                                    case 1:
                                        Console.Write("Введите слово, которое хотите добавить в словарь:");
                                        string newWord = Console.ReadLine();
                                        Console.Write("Введите слово, которое хотите добавить в качестве перевода:");
                                        string translationOption = Console.ReadLine();
                                        myDictionary.AddNewWord(newWord, translationOption);
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("\nСлово и его перевод успешно добавлены в словарь\n");
                                        Console.ResetColor();
                                        break;
                                    case 2:
                                        Console.Write("Введите слово, которое хотите добавить в словарь:");
                                        string newWord2 = Console.ReadLine();
                                        Console.WriteLine("Введите варианты перевода, разделяя каждый запятой:");
                                        string translationOptions = Console.ReadLine();
                                        List<string> listOfTranslationsOptions = translationOptions.Split(',').ToList();
                                        myDictionary.AddNewWord(newWord2, listOfTranslationsOptions);
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("\nСлово и его переводы успешно добавлены в словарь\n");
                                        Console.ResetColor();
                                        break;
                                    case 3:
                                        Console.WriteLine("Вы хотите добавить:\n" +
                                            "1.Один вариант перевода\n" +
                                            "2.Несколько вариантов перевода\n" +
                                            "3.Вернуться в основное меню\n");
                                        int choice5;
                                        while (true)
                                        {
                                            try
                                            {
                                                choice5 = int.Parse(Console.ReadLine());
                                            }
                                            catch (FormatException)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Введите число");
                                                Console.ResetColor();
                                                continue;
                                            }
                                            switch (choice5)
                                            {
                                                case 1:
                                                    Console.Write("Введите слово, к которому вы хотите добавить новый перевод:");
                                                    string word = Console.ReadLine();
                                                    Console.Write("Введите слово, которое хотите добавить в качестве перевода:");
                                                    string translationOption2 = Console.ReadLine();
                                                    try
                                                    {
                                                        myDictionary.AddNewTranslationOption(word, translationOption2);
                                                    }
                                                    catch (KeyNotFoundException)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Такого ключевого слова не найдено в словаре\n");
                                                        Console.ResetColor();
                                                        break;
                                                    }
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("\nНовый перевод слова успешно добавлен в словарь\n");
                                                    Console.ResetColor();
                                                    break;
                                                case 2:
                                                    Console.Write("Введите слово, к которому вы хотите добавить новые переводы:");
                                                    string word2 = Console.ReadLine();
                                                    Console.Write("Введите слова, которые хотите добавить в качестве перевода, разделяя каждое запятой:");
                                                    string translationOptions2 = Console.ReadLine();
                                                    try
                                                    {
                                                        myDictionary.AddNewTranslationOption(word2, translationOptions2);
                                                    }
                                                    catch (KeyNotFoundException)
                                                    {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine("Такого ключевого слова не найдено в словаре\n");
                                                        Console.ResetColor();
                                                        break;
                                                    }
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("\nНовые переводы слова успешно добавлены в словарь\n");
                                                    Console.ResetColor();
                                                    break;
                                                case 3:
                                                    MainMenu(myDictionary);
                                                    break;
                                                default:
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Такого пункта меню нет");
                                                    Console.ResetColor();
                                                    continue;
                                            }
                                            break;
                                        }

                                        break;
                                    case 4:
                                        MainMenu(myDictionary);
                                        break;
                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Такого пункта меню нет");
                                        Console.ResetColor();
                                        continue;
                                }
                            }
                            catch (ThisWordAlreadyExists ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(ex.Message);
                                Console.ResetColor();
                                continue;
                            }
                            UpdateDictionary(myDictionary);
                            break;
                        }
                        break;
                    #endregion
                    case 2:
                        #region case2
                        List<string> wordTranslations = new List<string>();
                        while (true)
                        {
                            Console.Write("Введите слово, над которым хотите выполнить изменение:");
                            string keyWord = Console.ReadLine();

                            if (!myDictionary.CheckIfSuchWordExistsInDictionary(myDictionary, keyWord))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Такого слова нет в словаре");
                                Console.ResetColor();
                                continue;
                            }

                            wordTranslations = myDictionary.SearchWordTranslations(keyWord);

                            Console.WriteLine($"Переводы слова {keyWord}:");
                            foreach (var translation in wordTranslations)
                            {
                                Console.WriteLine($"\t{translation}");
                            }
                            while (true)
                            {
                                Console.WriteLine("Вы хотите заменить слово, или один из его переводов?\n" +
                                    "1.Заменить слово\n" +
                                    "2.Заменить один из переводов\n" +
                                    "3.Вернуться в основное меню");
                                int choice3;
                                try
                                {
                                    choice3 = int.Parse(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Введите число");
                                    Console.ResetColor();
                                    continue;
                                }
                                switch (choice3)
                                {
                                    case 1:
                                        Console.Write("Введите новое слово:");
                                        string newWord2 = Console.ReadLine();
                                        Console.WriteLine();
                                        myDictionary.ReplaceKeyWord(newWord2);
                                        UpdateDictionary(myDictionary);

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("\nСлово успешно изменено");
                                        Console.ResetColor();
                                        break;
                                    case 2:
                                        while (true)
                                        {
                                            Console.Write("Введите перевод из списка, который вы хотите заменить:");
                                            string oldTranslationOption = Console.ReadLine();
                                            if (!wordTranslations.Contains(oldTranslationOption))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("\nТакого перевода нет в списке");
                                                Console.ResetColor();
                                                continue;
                                            }
                                            Console.Write("Введите новый перевод слова:");
                                            string newTranslationOption = Console.ReadLine();

                                            myDictionary.ReplaceTranslationOption(keyWord, oldTranslationOption, newTranslationOption);
                                            UpdateDictionary(myDictionary);

                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Перевод успешно изменен\n");
                                            Console.ResetColor();
                                            break;
                                        }
                                        break;
                                    case 3:
                                        MainMenu(myDictionary);
                                        break;
                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Такого пункта меню нет");
                                        Console.ResetColor();
                                        continue;
                                }
                                break;
                            }

                            break;
                        }
                        break;
                    #endregion
                    case 3:
                        #region case3
                        List<string> wordTranslations2 = new List<string>();
                        while (true)
                        {
                            Console.Write("Введите слово, над которым хотите выполнить изменение:");
                            string keyWord = Console.ReadLine();

                            if (!myDictionary.CheckIfSuchWordExistsInDictionary(myDictionary, keyWord))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Такого слова нет в словаре\n");
                                Console.ResetColor();
                                continue;
                            }

                            wordTranslations2 = myDictionary.SearchWordTranslations(keyWord);

                            Console.WriteLine($"\nПереводы слова {keyWord}:");
                            foreach (var translation in wordTranslations2)
                            {
                                Console.WriteLine($"- {translation}");
                            }

                            Console.WriteLine("Вы хотите удалить слово или один из его переводов?\n" +
                                "1.Удалить слово\n" +
                                "2.Удалить один из переводов\n" +
                                "3.Вернуться в основное меню");
                            while (true)
                            {
                                int choice3;
                                try
                                {
                                    choice3 = int.Parse(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Введите число");
                                    Console.ResetColor();
                                    continue;
                                }
                                switch (choice3)
                                {
                                    case 1:
                                        myDictionary.DeleteWordWithTranslations(keyWord);
                                        UpdateDictionary(myDictionary);
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Слово успешно удалено");
                                        Console.ResetColor();
                                        break;
                                    case 2:
                                        while (true)
                                        {
                                            Console.Write("Введите перевод из списка, который вы хотите удалить:");
                                            string translationOption = Console.ReadLine();

                                            if (!wordTranslations2.Contains(translationOption))
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Такого перевода нет в списке\n");
                                                Console.ResetColor();
                                                continue;
                                            }
                                            try
                                            {
                                                myDictionary.DeleteTranslationOption(keyWord, translationOption);
                                                UpdateDictionary(myDictionary);
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Перевод успешно удален\n");
                                                Console.ResetColor();
                                            }
                                            catch (TryingDeletLastTranslationsOption ex)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine($"{ex.Message}\n");
                                                Console.ResetColor();
                                            }
                                            break;
                                        }

                                        break;
                                    case 3:
                                        MainMenu(myDictionary);
                                        break;
                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Такого пункта меню нет");
                                        Console.ResetColor();
                                        continue;
                                }
                                break;
                            }
                            break;
                        }
                        break;
                    #endregion
                    case 4:
                        #region case4
                        while (true)
                        {
                            Console.Write("Введите слово, перевод(-ы) которого вы хотите посмотреть:");
                            bool restart = false;
                            while (true)
                            {
                                string keyWord = Console.ReadLine();
                                if (!myDictionary.CheckIfSuchWordExistsInDictionary(myDictionary, keyWord))
                                {

                                    while (true)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Такого слова нет в словаре\n");
                                        Console.ResetColor();
                                        Console.WriteLine("Выберите пункт меню:\n" +
                                            "1.Ввести другое слово\n" +
                                            "2.Вернуться в главное меню");
                                        int choice3 = int.Parse(Console.ReadLine());
                                        switch (choice3)
                                        {
                                            case 1:
                                                restart = true;
                                                break;
                                            case 2:
                                                Console.Clear();
                                                MainMenu(myDictionary);
                                                break;
                                            default:
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Такого пункта меню нет");
                                                Console.ResetColor();
                                                continue;
                                        }
                                        break;
                                    }
                                }
                                else
                                {
                                    List<string> translationOptions = myDictionary.SearchWordTranslations(keyWord);
                                    Console.WriteLine($"\nВарианты перевода слова {keyWord}:");
                                    foreach (var translationOption in translationOptions)
                                    {
                                        Console.WriteLine($"- {translationOption}");
                                    }
                                    Console.WriteLine();
                                }
                                break;
                            }

                            if (restart)
                            {
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }

                        #endregion
                        break;
                    case 5:
                        #region case5
                        Dictionary<string, List<string>> dictionary = myDictionary.GetDictionary();
                        foreach (var keyWord in dictionary)
                        {
                            Console.WriteLine(keyWord.Key + ":");
                            foreach (var translation in keyWord.Value)
                            {
                                Console.WriteLine($"- {translation}");
                            }
                            Console.WriteLine("******************");
                        }

                        #endregion
                        break;
                    case 6:
                        Console.Clear();
                        myDictionary = Start();
                        MainMenu(myDictionary);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Такого пункта меню нет");
                        Console.ResetColor();
                        break;
                }
            }
        }


        static void CheckIfDictionariesCreated()
        {
            string path = $"{Environment.CurrentDirectory}" + @"\MyDictionaries";

            DirectoryInfo dirInfo = new DirectoryInfo(path);
            FileInfo[] dictionaries = dirInfo.GetFiles();

            if (dictionaries.Length < 1)
            {
                using (FileStream fStream = File.OpenWrite(path + @"\EnglishRussianDictionary"))
                {
                    MyDictionary englishRussian = new MyDictionary(LanguageType.EnglishRussian);
                    BinaryFormatter binFormat = new BinaryFormatter();
                    binFormat.Serialize(fStream, englishRussian);
                }
                using (FileStream fStream = File.OpenWrite(path + @"\RussianEnglishDictionary"))
                {
                    MyDictionary russianEnglish = new MyDictionary(LanguageType.RussianEnglish);
                    BinaryFormatter binFormat = new BinaryFormatter();
                    binFormat.Serialize(fStream, russianEnglish);
                }
            }
        }

        static MyDictionary GetDictionary(LanguageType type)
        {

            string path = $"{Environment.CurrentDirectory}" + @"\MyDictionaries";

            DirectoryInfo dirInfo = new DirectoryInfo(path);
            FileInfo[] dictionaries = dirInfo.GetFiles();
            BinaryFormatter binFormatt = new BinaryFormatter();

            foreach (var file in dictionaries)
            {
                MyDictionary currentDictionary;

                using (FileStream fStream = File.OpenRead(path + $@"\{file.Name}"))
                {
                    currentDictionary = (MyDictionary)binFormatt.Deserialize(fStream);
                    if (currentDictionary.dictionaryType == type)
                    {
                        return currentDictionary;
                    }
                }
            }

            return null;
        }

        static void UpdateDictionary(MyDictionary myDictionary)
        {
            string path = $"{Environment.CurrentDirectory}" + @"\MyDictionaries";

            DirectoryInfo dirInfo = new DirectoryInfo(path);
            FileInfo[] files = dirInfo.GetFiles();

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            foreach (var file in files)
            {
                MyDictionary dictionary;
                using (FileStream fStream = File.Open(path + $@"\{file.Name}", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Delete))
                {
                    dictionary = (MyDictionary)binaryFormatter.Deserialize(fStream);
                    if (dictionary.dictionaryType == myDictionary.dictionaryType)
                    {
                        File.Delete(path + @$"\{file.Name}");

                        using (Stream fStream2 = File.Create(path + @$"\{file.Name}"))
                        {
                            binaryFormatter.Serialize(fStream2, myDictionary);
                        }
                    }
                }

            }

        }

    }
}