# hexagonalThis
A simple kata to live-code with Alistair about Hexagonal Architecture


## Ports? Adapters?

### Ports
A port matches an intention (i.e. an interface in C# or java) but may have multiple verbs. e.g.:

````CSharp

    // The 1st port to 'enter' the Hexagon
    public interface IProvideVerses
    {
        string GiveMeSomePoetry();
        string GiveMeLinesOfPoetry(int numberOfLine);
    }

````

__Note: All ports belongs to the Domain side__

Here, we have:
- one port to enter/ask the hexagon: [__IProvideVerses__](https://github.com/tpierrain/hexagonalThis/blob/confCallWithAlistair/HexagonalThis.Domain/Poet.cs#L7)
- one port for the hexagon to look for some poetry outside of it: [__IKnowABunchOfPoetry__](https://github.com/tpierrain/hexagonalThis/blob/confCallWithAlistair/HexagonalThis.Domain/IKnowABunchOfPoetry.cs)

### Adapters
__An Adapter is something that belongs to the Infra(structure) side__ and which allows to enter/exit the hexagon. An Adapter is both our code which maps the infra <->domain data models and vice-versa (i.e. the GoF adapter pattern way) and everything that allow us to enter/exit the hexagon (e.g.: database driver, HTTP stack, etc).

Here, we have so far 1 Adapter:
 - [__ConsoleAdapter__](https://github.com/tpierrain/hexagonalThis/blob/confCallWithAlistair/HexagonalThis.Console/Adapters/ConsoleAdapter.cs)


![Hexagon](https://github.com/tpierrain/hexagonalThis/blob/confCallWithAlistair/HexagonalThis.png?raw=true)