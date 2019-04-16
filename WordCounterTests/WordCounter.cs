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
            if(_textToProcess == null)
            {
                return new WordAndCount[] { };
            }
            else
            {
                var words = _textToProcess.Split(' ');
                var wordList = words.Select(x => new WordAndCount(x, 1)).ToArray();
                return wordList;
            }
            
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