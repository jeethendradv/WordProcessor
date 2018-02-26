using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordProcessor
{
    public class WordsProcessor
    {
        public void Process(string filePath)
        {
            List<Word> words = ReadFile(filePath);
            Console.WriteLine("=============================================");
            Console.WriteLine("Number of words to Process: {0}", words.Count);
            Console.WriteLine("=============================================");
            for (int index = 0; index < words.Count ; index++)
            {
                Word wordToProcess = words[index];
                if (!wordToProcess.IsComplete())
                {
                    FindWords(wordToProcess, words, index);
                }
                Console.WriteLine("\rNumber of words processed: {0} \t\t word: {1}                   ", index + 1, words[index].Name);
            }
            List<Word> processedWords = words.Where(w => w.IsComplete()).OrderByDescending(w => w.NumberOfWordsItContains).ToList();
            Word longestWord = processedWords.First();
            Word secondWord = processedWords[1];
            Console.WriteLine();
            Console.WriteLine("====================Results======================");
            Console.WriteLine("List of longest words:");
            Console.WriteLine("--------------------------------------------------");
            foreach (Word word in processedWords.Take(30))
            {
                Console.WriteLine("{0} = {1}", word.Name, word.GetChildWords());
            }
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Total count of words: {0}", processedWords.Count);
            Console.WriteLine("================================================");
        }

        private void FindWords(Word word, List<Word> words, int index)
        {
            for (int upperIndex = words.Count - 1; upperIndex >= 0; upperIndex--)
            {
                if (index != upperIndex)
                {
                    if (word.IsComplete())
                    {
                        break;
                    }
                    word.CheckContainsAndAdd(words[upperIndex]);
                }
            }
        }

        private List<Word> ReadFile(string filePath)
        {
            List<Word> words = new List<Word>();
            string[] lines = File.ReadAllLines(filePath);
            foreach (string word in lines.OrderBy(w => w).ToList())
            {
                if (!string.IsNullOrEmpty(word))
                {
                    words.Add(new Word
                    {
                        Name = word,
                        StringsToSearch = new List<string> { word }
                    });
                }
            }
            return words;
        }
    }
}
