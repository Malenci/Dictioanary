using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionaries
{
    public enum LanguageType
    {
        EnglishRussian,
        RussianEnglish
    }

    [Serializable]
    public class MyDictionary
    {
        private Dictionary<string, List<string>> dictionary;
        public LanguageType dictionaryType { get; }

        public MyDictionary(LanguageType languegeType)
        {
            dictionaryType = languegeType;
            dictionary = new Dictionary<string, List<string>>();
        }

        public void AddNewWord(string newWord, string translationOption)
        {
            try
            {
                dictionary.Add(newWord, new List<string> { translationOption });
            }
            catch (ArgumentException)
            {
                throw new ThisWordAlreadyExists("Введенное слово уже есть в словаре");
            }
        }

        public void AddNewWord(string newWord, List<string> translationOptions) => dictionary.Add(newWord, translationOptions);

        public void AddNewTranslationOption(string keyWord, string translationOption) => dictionary[keyWord].Add(translationOption);
        public void AddNewTranslationOption(string keyWord, List<string> translationsOptions) => dictionary[keyWord].AddRange(translationsOptions);

        public void DeleteTranslationOption(string keyWord, string translationOption)
        {
            if (dictionary[keyWord].Count > 1)
            {
                dictionary[keyWord].Remove(translationOption);
            }
            else
            {
                throw new TryingDeletLastTranslationsOption("Вы не можете удалить последний вариант перевода");
            }
        }

        public void DeleteWordWithTranslations(string keyWord) => dictionary.Remove(keyWord);

        public void ReplaceKeyWord(string keyWord)
        {
            List<string> translationOptions = dictionary[keyWord];
            dictionary.Remove(keyWord);
            dictionary.Add(keyWord, translationOptions);
        }
        public void ReplaceTranslationOption(string keyWord, string oldTranslationOption, string newTranslationOption)
        {
            dictionary[keyWord].Remove(oldTranslationOption);
            dictionary[keyWord].Add(newTranslationOption);
        }

        public List<string> SearchWordTranslations(string keyWord) => dictionary[keyWord];

        public Dictionary<string, List<string>> GetDictionary()
        {
            return dictionary;
        }

        public bool CheckIfSuchWordExistsInDictionary(MyDictionary dictionary, string keyWord)
        {
            try
            {
                var temp = dictionary.dictionary[keyWord];
            }
            catch (KeyNotFoundException)
            {
                return false;
            }

            return true;
        }


    }
}