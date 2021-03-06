﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace WordCounterTests
{
    public class WordCounter
    {
        
        private string _textToProcess;
        private string _fileToProcess;
        private IFileLoader _fileLoader;
        public WordCounter()
        {

        }

        public WordCounter(IFileLoader fileLoader)
        {
            _fileLoader = fileLoader;
        }

        public WordAndCount[] GetTop10Words()
        {
            if (!string.IsNullOrEmpty(_fileToProcess))
                return ProcessFile();
            else if (IsStringEmpty())
                return new WordAndCount[] { };
            else
                return ProcessText();
            
        }

        private WordAndCount[] ProcessFile()
        {
            return ProcessWords(_fileLoader.GetWords(_fileToProcess));
        }

        private WordAndCount[] ProcessWords(string[] words)
        {
            return words.Select(x => OnlyAlphaNumericWords(x.ToLowerInvariant()).Trim())
               .Where(x => IsNotEmpty(x))
               .GroupBy(word => word)
               .Select(x => new WordAndCount(x.Key, x.Count()))
               .OrderByDescending(word => word.Count).ThenByDescending(item => item.Word)
               .Take(10)
               .ToArray();
        }
        private WordAndCount[] ProcessText()
        {
            var words = _textToProcess.Split(' ');

            return ProcessWords(words);
        }

        private static string OnlyAlphaNumericWords(string wordToCheck)
        {
            Regex r = new Regex("[^a-zA-Z0-9]");
            return r.Replace(wordToCheck, " ");
        }

        private static bool IsNotEmpty(string x)
        {
            return !string.IsNullOrEmpty(x?.Trim());
        }

        private bool IsStringEmpty()
        {
            return _textToProcess == null;
        }

        internal void LoadText(string sampleText)
        {
            _textToProcess = sampleText;
            
        }

        internal void LoadFile(string filePath)
        {
            _fileToProcess = filePath;
        }
    }
    public interface IFileLoader
    {
        string[] GetWords(string filePath);

    }

    public class FileLoader : IFileLoader{

        public string[] GetWords(string filePath)
        {

            string[] lines;
            var list = new List<string>();
            var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.AddRange(line.Split(' '));
                }
            }
            return list.ToArray();
        }
    }
    public class WordAndCount
    {

        public WordAndCount(string word, int count)
        {
            Count = count;
            Word = word;
        }
        public string Word { get; private set; }
        public int Count { get; private  set; }
    }
}