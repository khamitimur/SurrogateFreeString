using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SurrogateFreeString.Tests
{
    [TestClass]
    public class SkinToneHelperTests
    {
        #region Fields

        private const string LIGHT_SKINTONE = "🏻";
        private const string MEDIUM_LIGHT_SKINTONE = "🏼";
        private const string MEDIUM_SKINTONE = "🏽";
        private const string MEDIUM_DARK_SKINTONE = "🏾";
        private const string DARK_SKINTONE = "🏿";
        private const string CRYING_EMOJI = "😭";
        private const string ADULT_EMOJI_WITH_DARK_SKINTONE = "🧑🏿";

        #endregion

        #region Tests

        [TestMethod]
        public void EmojiAwareString_IsSkinToneModifier()
        {
            Assert.AreEqual(true, LIGHT_SKINTONE.IsSkinToneModifier());
            Assert.AreEqual(true, MEDIUM_LIGHT_SKINTONE.IsSkinToneModifier());
            Assert.AreEqual(true, MEDIUM_SKINTONE.IsSkinToneModifier());
            Assert.AreEqual(true, MEDIUM_DARK_SKINTONE.IsSkinToneModifier());
            Assert.AreEqual(true, DARK_SKINTONE.IsSkinToneModifier());
            Assert.AreEqual(false, CRYING_EMOJI.IsSkinToneModifier());
            Assert.AreEqual(false, ADULT_EMOJI_WITH_DARK_SKINTONE.IsSkinToneModifier());
            Assert.AreEqual(false, "".IsSkinToneModifier());
            Assert.AreEqual(false, "This is a library!".IsSkinToneModifier());
            Assert.AreEqual(false, SkinToneHelper.IsSkinToneModifier(null));
        }

        #endregion
    }
}