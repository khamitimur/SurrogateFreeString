namespace SurrogateFreeString
{
    public static class ZeroWidthJoinerHelper
    {
        #region Fields

        private const char ZERO_WIDTH_JOINER = '\u200b';

        #endregion

        #region Properties

        public static char ZeroWidthJoiner => ZERO_WIDTH_JOINER;

        #endregion

        #region Public Methods

        public static bool IsZeroWidthJoiner(this char @char)
        {
            return @char == ZERO_WIDTH_JOINER;
        }

        #endregion
    }
}