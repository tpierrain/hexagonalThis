# hexagonalThis
A simple kata to live-code with Alistair about Hexagonal Architecture


## Ports? Adapters?

### Ports
A port matches one intention (usually an interface in C# or java) but may have multiple verbs/methods. e.g.:

````CSharp

    // The 1st port to ask/enter the hexagon
    public interface IProvideVerses
    {
        string GiveMeSomePoetry();
        string GiveMeLinesOfPoetry(int numberOfLine);
    }


    // The 1st port to exit the hexagon 
    // (by looking for some poetry outside of it)
    public interface IKnowABunchOfPoetry
    {
        string GetPoem();
    }

````

#### Note: All ports belong to the Domain side


### Adapters
__An Adapter is something that belongs to the Infra(structure) side__ and which allows to enter/exit the hexagon. An Adapter is both our code which maps the infra <-> domain data models (i.e. in the GoF adapter pattern sense) and everything that allows us to enter/exit the hexagon (e.g.: a database driver, your favorite HTTP stack, etc).

Here, we have 1 Adapter so far:
 - [__ConsoleAdapter__](https://github.com/tpierrain/hexagonalThis/blob/confCallWithAlistair/HexagonalThis.Console/Adapters/ConsoleAdapter.cs)

Here is a typical method from this Adapter:

````CSharp

    public void RequestFirstVersesForAPoem(string line)
    {
        // Map the request passed by the infra side (here Console app arguments)
        int numberOfLine = int.Parse(line);

        // Call the business logic
        var verses = this.poet.GiveMeLinesOfPoetry(numberOfLine);

        // Get back with the answer onto the Infra side (Console)
        this.publicationStrategy.WriteLine(verses);
    }

````

## The Hexagon

The hexagon must expose one or multiple ports. Here, the [__Poet__](https://github.com/tpierrain/hexagonalThis/blob/confCallWithAlistair/HexagonalThis.Domain/Poet.cs#L13) hexagon implements the __IProvideVerses__ port and use the __IKnowABunchOfPoetry__ port to ask an external service some poetry to work with.

![Hexagon](https://github.com/tpierrain/hexagonalThis/blob/confCallWithAlistair/HexagonalThis.png?raw=true)


## A 3 steps initialization

![Hexagon](https://github.com/tpierrain/hexagonalThis/blob/confCallWithAlistair/A3StepsInitialization.PNG?raw=true)


