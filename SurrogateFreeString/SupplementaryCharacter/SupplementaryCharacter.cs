using System;
using System.Collections.Generic;

namespace SurrogateFreeString
{
    /// <summary>
    /// Implementation of <see cref="ISupplementaryCharacter"/>.
    /// </summary>
    internal class SupplementaryCharacter : ISupplementaryCharacter
    {
        #region Fields

        private List<char> charsList = new List<char>();

        #endregion

        #region Constructor

        public SupplementaryCharacter(char @char)
        {
            charsList.Add(@char);
        }

        #endregion

        #region Properties

        /// <inheritdoc cref="ISupplementaryCharacter.CharsList" />
        public IList<char> CharsList => charsList;

        /// <inheritdoc cref="ISupplementaryCharacter.CharsCount" />
        public int CharsCount => charsList.Count;

        #endregion

        #region Overrides of Object

        public override string ToString()
        {
            return new string(charsList.ToArray());
        }

        #endregion

        #region Overrides of ISupplementaryCharacter

        /// <inheritdoc cref="ISupplementaryCharacter.Add(char)" />
        public ISupplementaryCharacter Add(char @char)
        {
            charsList.Add(@char);

            return this;
        }

        /// <inheritdoc cref="ISupplementaryCharacter.Insert(int, char)" />
        public ISupplementaryCharacter Insert(int index, char @char)
        {
            if (index < 0) throw new ArgumentException($"{nameof(@char)} can't be lower than 0.", nameof(@char));

            charsList.Insert(index, @char);

            return this;
        }

        /// <inheritdoc cref="ISupplementaryCharacter.EndsWithHighSurrogate()" />
        public bool EndsWithHighSurrogate()
        {
            if (charsList.Count > 0)
            {
                return char.IsHighSurrogate(charsList[charsList.Count - 1]);
            }

            return false;
        }

        #endregion
    }
}