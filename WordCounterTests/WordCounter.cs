using System.Linq;
using System.Text.RegularExpressions;

namespace WordCounterTests
{
    public class WordCounter
    {
        
        private string _textToProcess;
        public WordCounter()
        {
            
        }

        public WordAndCount[] GetTop10Words()
        {
            if (IsStringEmpty())
                return new WordAndCount[] { };
            else
                return ProcessText();
            
        }

        private WordAndCount[] ProcessText()
        {
            var words = _textToProcess.Split(' ');

            return words.Select(x => OnlyAlphaNumericWords(x))
                .Where(x => IsNotEmpty(x))
                .GroupBy(word => word)
                .Select(x => new WordAndCount(x.Key, x.Count()))
                .OrderByDescending(wordAndCount=> wordAndCount.Count)
                .ToArray();
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