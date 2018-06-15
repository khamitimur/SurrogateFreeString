namespace SurrogateFreeString
{
    public static class StringExtensions
    {
        #region Public Methods

        public static ISFString ToSFString(this string source)
        {
            return new SFString(source);
        }

        #endregion
    }
}