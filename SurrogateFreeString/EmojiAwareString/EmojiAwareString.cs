﻿using System;
using System.Collections.Generic;

namespace SurrogateFreeString
{
    public class EmojiAwareString : IEmojiAwareString
    {
        #region Fields

        private Lazy<List<StringItem>> items;

        #endregion

        #region Constructor

        public EmojiAwareString(string @string)
        {
            @String = @string ?? throw new ArgumentNullException($"{nameof(@string)} can't be null.", nameof(@string));

            items = new Lazy<List<StringItem>>(() => GetItems());
        }

        #endregion

        #region Properties

        public string @String { get; }

        #endregion

        #region Overides of IEmojiAwareString

        public int Length => items.Value.Count;

        #endregion

        #region Private Methods

        private List<StringItem> GetItems()
        {
            var items = new List<StringItem>();

            // Can't be null but whatever.
            if (string.IsNullOrEmpty(@String))
                return items;

            var charsMapItemsList = GetCharsMapItemsList();
            foreach (var charMapItem in charsMapItemsList)
            {

            }

            return items;
        }

        private List<CharMapItem> GetCharsMapItemsList()
        {
            var charsMapList = new List<CharMapItem>();

            foreach (var @char in @String)
            {
                if (char.IsHighSurrogate(@char))
                {
                    charsMapList.Add(new CharMapItem(@char, StringItemType.HighSurrogate));
                }
                else if (char.IsLowSurrogate(@char))
                {
                    charsMapList.Add(new CharMapItem(@char, StringItemType.LowSurrogate));
                }
                else if (@char.IsZeroWidthJoiner())
                {
                    charsMapList.Add(new CharMapItem(@char, StringItemType.ZeroWidthJoiner));
                }
                else
                {
                    charsMapList.Add(new CharMapItem(@char, StringItemType.BasicMultilingualPlane));
                }
            }

            return charsMapList;
        }

        #endregion
    }

    public struct CharMapItem
    {
        #region Constructor

        public CharMapItem(char @char, StringItemType type)
        {
            @Char = @char;
            Type = type;
        }

        #endregion

        #region Properties

        public char @Char { get; }

        public StringItemType Type { get; }

        #endregion
    }

    public enum StringItemType
    {
        HighSurrogate,
        LowSurrogate,
        ZeroWidthJoiner,
        BasicMultilingualPlane
    }
}