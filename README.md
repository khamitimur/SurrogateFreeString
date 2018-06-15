# SurrogateFreeString

A small library to help you manipulate strings without paying attention to supplementary characters.
You can visit [MSDN](https://msdn.microsoft.com/ru-ru/library/windows/desktop/dd374069(v=vs.85).aspx) for detailed information about supplementary characters and surrogates.

## How To

Create new `SFString` object by passing your string into a constructor.

```c#
string exampleString = @"This 👉 is 🅰 an example string with emojis 👨‍👩‍👧‍👧.";
SFString surrogateFreeString = new SFString(exampleString);
```
This will create a representation of your string where all surrogate pairs will count as one symbol.
After that you can manipulate it just like a `string`. Actually for now there are only `Substring(int, int)` and `Substring(int)` methods.

```c#
SFString firstToCharacters = surrogateFreeString.Substring(0, 2);
SFString allCharactersAfterFirstTwo = surrogateFreeString.Substring(2);
```

To get a `string` after you finished minupulations you wanted just use `ToString()`.

```c#
var finalString = firstToCharacters.ToString();
```

## License

This project is licensed under the WTFPL License.
See the [LICENSE](LICENSE) file for details.
