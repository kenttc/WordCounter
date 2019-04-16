﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordCounterTests
{
    [TestClass]
    public class WordCounterTests
    {
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
            var sampleText = "sample";
            wordCounter.LoadText(sampleText);
            //act
            var result = wordCounter.GetTop10Words();
            //assert
            Assert.AreEqual(1, result.Length);

        }


    }
}
