using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordCounterTests
{
    [TestClass]
    public class WordCounterTests
    {
        /// <summary>
        /// assumptions - words are spaced , 
        /// and empty spaces are not counted. 
        /// </summary>

        private static WordCounter GetWordCounter(string sampleText)
        {
            var wordCounter = new WordCounter();
            wordCounter.LoadText(sampleText);
            return wordCounter;
        }

        [TestMethod]
        public void Given_an_unloaded_wordcounter_will_return_list_of_empty_texts()
        {
            //arrange
            var wordCounter = new WordCounter();
            //act
            var result = wordCounter.GetTop10Words();
            //assert
            Assert.AreEqual(0, result.Length);

        }

        [TestMethod]
        public void Given_a_wordcounter_loaded_with_1_word_will_return_list_of_text_containing_1_word_and_count_of_1()
        {
            SingleWordCountVerification("sample", "sample", 1);
        }

        [TestMethod]
        public void Given_a_wordcounter_loaded_with_2_same_word_will_return_list_of_text_containing_1_word_and_count_of_2()
        {
            SingleWordCountVerification("sample sample", "sample", 2);
        }

        [TestMethod]
        public void Given_a_wordcounter_loaded_with_2_same_word_And_1_different_word_will_return_list_of_text_containing_1_word_and_count_of_2_and_1()
        {
            //arrange
            var wordCounter = GetWordCounter("sample sample fox");
            //act
            var result = wordCounter.GetTop10Words();
            //assert
            Assert.AreEqual("sample", result[0].Word);
            Assert.AreEqual(2, result[0].Count);
            Assert.AreEqual("fox", result[1].Word);
            Assert.AreEqual(1, result[1].Count);
        }

        [TestMethod]
        public void Given_a_wordcounter_loaded_with_word_has_leading_and_trailling_spaces_will_ignore_leading_and_empty_spaces()
        {
            SingleWordCountVerification("      sample     ", "sample", 1);
        }

        [TestMethod]
        public void Given_a_wordcounter_loaded_with_word_has_specialcharacters_will_specialcharacters()
        {
            SingleWordCountVerification("sample .", "sample", 1);
        }

        private static void SingleWordCountVerification(string text, string expectedString, int expectedWordCount)
        {
            //arrange
            var wordCounter = GetWordCounter(text);
            //act
            var result = wordCounter.GetTop10Words();
            //assert
            Assert.AreEqual(expectedString, result[0].Word);
            Assert.AreEqual(expectedWordCount, result[0].Count);
            Assert.AreEqual(1, result.Length);
        }
    }
}
