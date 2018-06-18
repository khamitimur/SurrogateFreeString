using System;

namespace SurrogateFreeString
{
    public class StringItem
    {
        #region Contructor

        public StringItem(int startIndex, string @string)
        {
            StartIndex = startIndex >= 0
                ? startIndex
                : throw new ArgumentException($"{nameof(startIndex)} can't be lower than zero.");
            String = @string ?? throw new ArgumentNullException($"{nameof(@string)} can't be null.", nameof(@string));
        }

        #endregion

        #region Properties

        public int StartIndex { get; }

        public string @String { get; }

        public int Lenght => String.Length;

        #endregion

        #region Methods



        #endregion
    }
}