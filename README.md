# SurrogateFreeString

A small library to help you manipulate strings without paying attention to supplementary characters.

## How To

Create new `SFString` object by passing your string into constructor

```c#
string exampleString = @"This 👉 is 🅰 test string with emojis 👨‍👩‍👧‍👧.";
SFString surrogateFreeString = new SFString(exampleString);
```

## License

This project is licensed under the WTFPL License - see the [LICENSE](LICENSE) file for details
