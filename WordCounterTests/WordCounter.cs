using System;

namespace WordCounterTests
{
    public class WordCounter
    {
        
        private string _textToProcess;
        public WordCounter()
        {
            
        }

        public string[] GetTop10Words()
        {
            if(_textToProcess == null)
            {
                return new string[] { };
            }
            else
            {
                var words = _textToProcess.Split(' ');

                return words;
            }
            
        }

        internal void LoadText(string sampleText)
        {
            _textToProcess = sampleText;
            
        }
    }
}