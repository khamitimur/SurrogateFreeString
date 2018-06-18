using System;
using System.Collections.Generic;

namespace SurrogateFreeString
{
    public static class SkinToneHelper
    {
        #region Fields

        private const string LIGHT_SKINTONE = "🏻";
        private const string MEDIUM_LIGHT_SKINTONE = "🏼";
        private const string MEDIUM_SKINTONE = "🏽";
        private const string MEDIUM_DARK_SKINTONE = "🏾";
        private const string DARK_SKINTONE = "🏿";

        private static IDictionary<string, SkinToneModifierName> skinToneModifiersDictionary;

        #endregion

        #region Contructor

        static SkinToneHelper()
        {
            skinToneModifiersDictionary = new Dictionary<string, SkinToneModifierName>
            {
                { LIGHT_SKINTONE, SkinToneModifierName.Light },
                { MEDIUM_LIGHT_SKINTONE, SkinToneModifierName.MediumLight },
                { MEDIUM_SKINTONE, SkinToneModifierName.Medium },
                { MEDIUM_DARK_SKINTONE, SkinToneModifierName.MediumDark },
                { DARK_SKINTONE, SkinToneModifierName.Dark }
            };
        }

        #endregion

        #region Properties

        public static string LightSkinTone => LIGHT_SKINTONE;

        public static string MediumLightSkinTone => MEDIUM_LIGHT_SKINTONE;

        public static string MediumSkinTone => MEDIUM_SKINTONE;

        public static string MediumDarkSkinTone => MEDIUM_DARK_SKINTONE;

        public static string DarkSkinTone => DARK_SKINTONE;

        #endregion

        #region Public Methods

        public static bool IsSkinToneModifier(char highSurrogate, char lowSurrogate)
        {
            if (!char.IsHighSurrogate(highSurrogate)) throw new ArgumentException($"{nameof(highSurrogate)} must be a high surrogate.");
            if (!char.IsHighSurrogate(lowSurrogate)) throw new ArgumentException($"{nameof(highSurrogate)} must be a low surrogate.");

            if (!char.IsSurrogatePair(highSurrogate, lowSurrogate))
                return false;

            return new string(highSurrogate, lowSurrogate).IsSkinToneModifier();
        }

        public static bool IsSkinToneModifier(this string @string)
        {
            if (string.IsNullOrWhiteSpace(@string))
                return false;

            if (skinToneModifiersDictionary.ContainsKey(@string))
                return true;

            return false;
        }

        #endregion
    }

    public enum SkinToneModifierName
    {
        Light,
        MediumLight,
        Medium,
        MediumDark,
        Dark
    }
}