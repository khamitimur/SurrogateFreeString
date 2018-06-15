using System.Collections.Generic;

namespace SurrogateFreeString
{
    /// <summary>
    /// Container for a BMP character or a surrogate pair.
    /// <para><remarks>
    /// https://en.wikipedia.org/wiki/Plane_(Unicode)
    /// </remarks></para>
    /// </summary>
    public interface ISupplementaryCharacter
    {
        #region Properties

        /// <summary>
        /// A list of <see cref="char"/>.
        /// </summary>
        IList<char> CharsList { get; }

        /// <summary>
        /// Number of items in <see cref="CharsList"/>.
        /// </summary>
        int CharsCount { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a new <see cref="char"/> to the end of the <see cref="CharsList"/>.
        /// </summary>
        /// <param name="char">The <see cref="char"/> to be added.</param>
        /// <returns></returns>
        ISupplementaryCharacter Add(char @char);

        /// <summary>
        /// Inserts a new <see cref="char"/> into <see cref="CharsList"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which <see cref="char"/> should be inserted.</param>
        /// <param name="char">The <see cref="char"/> to be inserted.</param>
        /// <returns></returns>
        ISupplementaryCharacter Insert(int index, char @char);

        /// <summary>
        /// Checks if last <see cref="char"/> in <see cref="CharsList"/> is high surrogate.
        /// <para><remarks>
        /// Returns false if <see cref="CharsList"/> is empty.
        /// </remarks></para>
        /// </summary>
        /// <returns></returns>
        bool EndsWithHighSurrogate();

        #endregion
    }
}