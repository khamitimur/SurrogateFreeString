namespace SurrogateFreeString
{
    public interface ISFString
    {
        #region Properties

        /// <summary>
        /// Get the number of <see cref="ISupplementaryCharacter"/> elements.
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Get the number of all <see cref="char"/> elements in hold by collection of <see cref="ISupplementaryCharacter"/>.
        /// <para><remarks>
        /// Similar to <see cref="string.Length"/>.
        /// </remarks></para>
        /// </summary>
        int ActualLength { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Retrieves a substring in a form of the <see cref="ISFString"/>.
        /// The substring starts at a specified character position and has a specified length.
        /// </summary>
        /// <param name="startIndex">The zero-based starting position.</param>
        /// <param name="count">The number of <see cref="ISupplementaryCharacter"/> in the substring.</param>
        /// <returns></returns>
        ISFString Substring(int startIndex, int count);

        /// <summary>
        /// Retrieves a substring in a form of the <see cref="ISFString"/>.
        /// The substring starts at a specified character and continues to the end.
        /// </summary>
        /// <param name="startIndex">The zero-based starting position.</param>
        /// <returns></returns>
        ISFString Substring(int startIndex);

        #endregion
    }
}