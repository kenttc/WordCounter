using System.Collections.Generic;
using System.Linq;
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
            var wordList = words.Where(x=> !string.IsNullOrEmpty(x))
                .GroupBy(word => word)
                .Select(x => new WordAndCount(x.Key, x.Count()))
                .ToArray();
            return wordList;
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