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
        public void Given_a_wordcounter_loaded_with_1_word_will_return_list_of_text_containing_1_word()
        {
            //arrange
            var wordCounter = new WordCounter();
            wordCounter.LoadText("sample");
            //act
            var result = wordCounter.GetTop10Words();
            //assert
            Assert.AreEqual(1, result.Length);
        }

        [TestMethod]
        public void Given_a_wordcounter_loaded_with_1_word_will_return_list_of_text_containing_1_word_and_count_of_1()
        {
            //arrange
            var wordCounter = new WordCounter();
            wordCounter.LoadText("sample");
            //act
            var result = wordCounter.GetTop10Words();
            //assert
            Assert.AreEqual("sample", result[0].Word);
            Assert.AreEqual(1, result[0].Count);
        }

        [TestMethod]
        public void Given_a_wordcounter_loaded_with_2_same_word_will_return_list_of_text_containing_1_word_and_count_of_2()
        {
            //arrange
            var wordCounter = new WordCounter();
            wordCounter.LoadText("sample sample");
            //act
            var result = wordCounter.GetTop10Words();
            //assert
            Assert.AreEqual("sample", result[0].Word);
            Assert.AreEqual(2, result[0].Count);
        }
    }
}
