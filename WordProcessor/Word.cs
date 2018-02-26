using System;
using System.Collections.Generic;
using System.Linq;

namespace WordProcessor
{
    public class Word
    {
        public Word()
        {
            listOfWords = new List<Word>();
        }
        private List<Word> listOfWords { get; set; }
        private int childWordsLength { get; set; }
        public int NumberOfWordsItContains
        {
            get
            {
                return listOfWords.Count;
            }
        }
        public string Name { get; set; }
        
        public List<string> StringsToSearch { get; set; }

        public void CheckContainsAndAdd(Word word)
        {
            if (Contains(word.Name) && !ContainsInWords(word))
            {
                Add(word);
                Replace(word.Name);
            }
        }

        private bool Contains(string word)
        {
            return StringsToSearch.Find(x => x.Contains(word)) != null;
        }

        private void Replace(string word)
        {
            List<string> stringToReplace = StringsToSearch.FindAll(s => s.Contains(word));
            List<string> newWords = new List<string>();
            foreach(string s in stringToReplace)
            {
                string[] splitResults = s.Split(new string[] { word }, StringSplitOptions.None);
                StringsToSearch.RemoveAll(x => x == s);
                foreach (string x in splitResults)
                {
                    if (!string.IsNullOrEmpty(x))
                    {
                        StringsToSearch.Add(x);
                    }
                }
            }
        }

        public bool ContainsInWords(Word word)
        {
            return listOfWords.Find(x => x.Name.Contains(word.Name) || x.ContainsInWords(word)) != null;
        }

        public void Add(Word word)
        {
            listOfWords.Add(word);
        }

        public bool IsComplete()
        {
            return StringsToSearch.Count == 0;
        }

        public string GetChildWords()
        {
            return string.Join(",", listOfWords.Select(x => x.Name));
        }
    }
}
