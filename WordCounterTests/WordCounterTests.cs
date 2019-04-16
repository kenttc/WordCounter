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
        public void WordCounter_to_show_only_alphanumeric_characters()
        {
            SingleWordCountVerification("sample .", "sample", 1);
            SingleWordCountVerification("sample %$£*&^", "sample", 1);

        }


        [TestMethod]
        public void WordCounter_to_show_Top3_words_ordered_by_word_count()
        {
            //arrange
            var wordCounter = GetWordCounter("fox sample sample fox sample jumped sample fox");
            //act
            var result = wordCounter.GetTop10Words();
            //assert
            CheckWordPositionAndCount(result, 1, "sample", 4);
            CheckWordPositionAndCount(result, 2, "fox", 3);
            CheckWordPositionAndCount(result, 3, "jumped", 1);

        }

        private static void CheckWordPositionAndCount(WordAndCount[] result, int expectedPosition, string expectedWord, int expectedCount)
        {
            Assert.AreEqual(expectedWord, result[expectedPosition-1].Word);
            Assert.AreEqual(expectedCount, result[expectedPosition-1].Count);
        }
        [TestMethod]
        public void WordCounter_to_show_Top10_words_when_words_are_loaded_by_file_order_by_count_and_word_desc()
        {
            //arrange
            var wordCounter = new WordCounter();
            string filepath = Environment.CurrentDirectory  + @"../../../lord_of_the_rings-sample.txt";
            wordCounter.LoadFile(filepath);
            //act
            var result = wordCounter.GetTop10Words();
            //assert
            Assert.AreEqual(10, result.Length);
            CheckWordPositionAndCount(result, 1, "the", 9);
            CheckWordPositionAndCount(result, 2, "of", 7);
            CheckWordPositionAndCount(result, 3, "shire", 2);
            CheckWordPositionAndCount(result, 4, "ring", 2);
            CheckWordPositionAndCount(result, 5, "r", 2);
            CheckWordPositionAndCount(result, 6, "concerning", 2);
            CheckWordPositionAndCount(result, 7, "weed", 1);
            CheckWordPositionAndCount(result, 8, "v", 1);
            CheckWordPositionAndCount(result, 9, "toikien", 1);
            CheckWordPositionAndCount(result, 10, "table", 1);
        }


    }
}
