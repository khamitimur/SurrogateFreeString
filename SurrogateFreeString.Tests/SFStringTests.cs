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
            var sfstring = new SFString(TEST_STRING);

            Assert.AreEqual(107, sfstring.Length);
        }

        [TestMethod]
        public void SFString_ActualLength()
        {
            var sfstring = new SFString(TEST_STRING);

            Assert.AreEqual(113, sfstring.ActualLength);
        }

        [TestMethod]
        public void SFString_ToString()
        {
            var sfstring = new SFString(TEST_STRING);

            Assert.AreEqual(TEST_STRING, sfstring.ToString());
        }

        #endregion
    }
}