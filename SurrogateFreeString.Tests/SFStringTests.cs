using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SurrogateFreeString.Tests
{
    [TestClass]
    public class SFStringTests
    {
        #region Fields

        private const string TEST_STRING = @"This 👉 is 🅰 test string with emojis 👨‍👩‍👧‍👧. Did you know that family emoji is just 4 emojis melt together?";

        #endregion

        #region Tests

        [TestMethod]
        public void SFString_Length()
        {
            var sfString = new SFString(TEST_STRING);

            Assert.AreEqual(107, sfString.Length);
        }

        [TestMethod]
        public void SFString_ActualLength()
        {
            var sfString = new SFString(TEST_STRING);

            Assert.AreEqual(113, sfString.ActualLength);
        }

        [TestMethod]
        public void SFString_ToString()
        {
            var sfString = new SFString(TEST_STRING);

            Assert.AreEqual(TEST_STRING, sfString.ToString());
        }

        [TestMethod]
        public void SFString_Substring()
        {
            var firstSubstringSFString = new SFString(TEST_STRING).Substring(0, 9);
            var secondSubstringSFString = new SFString(TEST_STRING).Substring(12);

            Assert.AreEqual(@"This 👉 is", firstSubstringSFString.ToString());
            Assert.AreEqual(@"test string with emojis 👨‍👩‍👧‍👧. Did you know that family emoji is just 4 emojis melt together?", secondSubstringSFString.ToString());
        }

        #endregion
    }
}