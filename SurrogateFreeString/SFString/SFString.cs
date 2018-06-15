using System;
using System.Collections.Generic;
using System.Linq;

namespace SurrogateFreeString
{
    /// <summary>
    /// Implementation of <see cref="ISFString"/>.
    /// </summary>
    public class SFString : ISFString
    {
        #region Fields

        /// <summary>
        /// List of <see cref="ISupplementaryCharacter"./>
        /// </summary>
        private IList<ISupplementaryCharacter> itemsList = new List<ISupplementaryCharacter>();

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SurrogateFreeString"/>
        /// with specified string.
        /// </summary>
        /// <param name="source"></param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
        public SFString(string source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            Create(source);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SurrogateFreeString"/>
        /// with specified <see cref="List{T}"/> of <see cref="ISupplementaryCharacter"/>.
        /// </summary>
        /// <param name="itemsList"></param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="itemsList"/> is null.</exception>
        internal SFString(IList<ISupplementaryCharacter> itemsList)
        {
            this.itemsList = itemsList ?? throw new ArgumentNullException(nameof(itemsList));
        }

        #endregion

        #region Overrides of Object

        public override string ToString()
        {
            var allCharsList = new List<char>();

            for (int i = 0; i < itemsList.Count; i++)
            {
                allCharsList.AddRange(itemsList[i].CharsList);
            }

            return new string(allCharsList.ToArray());
        }

        #endregion

        #region Overrides of ISFString

        /// <inheritdoc cref="ISFString.Length" />
        public int Length => itemsList.Count;

        /// <inheritdoc cref="ISFString.ActualLength" />
        public int ActualLength => itemsList.Sum(iSupplementaryCharacter => iSupplementaryCharacter.CharsCount);

        /// <inheritdoc cref="ISFString.Substring(int, int)" />
        public ISFString Substring(int startIndex, int count)
        {
            if (startIndex < 0) throw new ArgumentException($"{nameof(startIndex)} can't be lower than 0.", nameof(startIndex));
            if (startIndex >= itemsList.Count) throw new ArgumentException($"{nameof(startIndex)} can't be higher than items count.", nameof(startIndex));
            if (count < 0) throw new ArgumentException($"{nameof(count)} can't be lower than 0.", nameof(count));
            if (startIndex + count > itemsList.Count) throw new ArgumentException($"The sum of {nameof(startIndex)} and {nameof(count)} can't be higher than items count.", nameof(startIndex));

            return new SFString(itemsList.Skip(startIndex).Take(count).ToList());
        }

        /// <inheritdoc cref="ISFString.Substring(int)" />
        public ISFString Substring(int startIndex)
        {
            if (startIndex < 0) throw new ArgumentException($"{nameof(startIndex)} can't be lower than 0.", nameof(startIndex));
            if (startIndex >= itemsList.Count) throw new ArgumentException($"{nameof(startIndex)} can't be higher than items count.", nameof(startIndex));

            return Substring(startIndex, itemsList.Count - startIndex);
        }

        #endregion

        #region Private Methods

        private void Create(string source)
        {
            var sourceCharArray = source.ToCharArray();
            foreach (var sourceChar in sourceCharArray)
            {
                if (char.IsHighSurrogate(sourceChar))
                {
                    AddHighSurrogateChar(sourceChar);
                }
                else if (char.IsLowSurrogate(sourceChar))
                {
                    if (itemsList.Count > 0)
                    {
                        if (itemsList[itemsList.Count - 1].EndsWithHighSurrogate())
                        {
                            InsertLowSurrogateChar(sourceChar);
                        }
                        else
                        {
                            AddLowSurrogateChar(sourceChar);
                        }
                    }
                    else
                    {
                        AddLowSurrogateChar(sourceChar);
                    }
                }
                else
                {
                    AddBMPChar(sourceChar);
                }
            }
        }

        private void AddHighSurrogateChar(char surrogateChar)
        {
            itemsList.Add(new SupplementaryCharacter(surrogateChar));
        }

        private void AddLowSurrogateChar(char surrogateChar)
        {
            itemsList.Add(new SupplementaryCharacter(surrogateChar));
        }

        private void InsertLowSurrogateChar(char surrogateChar)
        {
            itemsList[itemsList.Count - 1].Add(surrogateChar);
        }

        private void AddBMPChar(char bmpChar)
        {
            itemsList.Add(new SupplementaryCharacter(bmpChar));
        }

        #endregion
    }
}