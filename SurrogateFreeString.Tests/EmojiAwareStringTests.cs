using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurrogateFreeString.Tests
{
    [TestClass]
    public class EmojiAwareStringTests
    {
        #region Fields

        private const string TEST_STRING = @"This 👉 is 🅰 test string with emojis 👨‍👩‍👧‍👧. Did you know that family emoji is just 4 emojis melt together?";

        #endregion

        #region Tests

        [TestMethod]
        public void EmojiAwareString_Length()
        {
            var eaString = new EmojiAwareString(TEST_STRING);

            Assert.AreEqual(107, eaString.Length);
        }

        #endregion
    }
}