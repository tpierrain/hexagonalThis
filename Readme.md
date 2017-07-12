# hexagonalThis
A simple kata to live-code with Alistair about Hexagonal Architecture

## Steps (carpaccio style)

### Alistair wants an application that provides poetry.

#### Steps:
1. Test-drive the design of our 1st port (i.e. the intention, represented in C# with an interface: __IRequestVerses__ and a first method: __GiveMeSomePoetry()__). 
    - This very first version of the business logic (i.e.: the __PoetryReader__ type) returns an hard-coded result.
    - The left-side adapter is both the unit test framework and the test calling the port

2. Write another acceptance test with the simplest possible __right-side adapter__: a stub for the new right-side port: __IObtainPoems__ and its unique __GetAPoem()__ method/verb.

3. Write another acceptance test to test-drive the usage of __a new Console (app) adapter__
    - Here, we need to mock the Console.WriteLine calls by introducing a ICanWriteLines strategy. This mock will assert that it has received the proper call after __GiveMeSomePoetry__ is called.
    - Proper time to illustrate the 3 steps initialization of the Hexagonal Architecture (i. Instantiate the "I need to go out" ports and adapters     ii. Instantiate the PoetryReader hexagon     iii. Instantiate the "I need to go in" ports and adapter)
    - Introduce here an "hexagon" wrapper onto the business logic (to explicit the architectural pattern for the years to come?)


4. Write a CONSOLE application (embedding the right-side mock) to __get end-users feedbacks about the way we will soon ask questions to the system__
    - Alistair's feedback (*playing the end-user*) is that we need to have other poems than the hard-coded one.

5. Test drive __a right-side PoemFileAdapter__ that will return the content of a file knowing its path (file being: Rimbaud.txt).




The application is now structurally complete (with left and right-side adapters). We can either:

    - Add a CycleThroughPoemsAdapter (that will leverage on the Poetry.json file)
    - Test drive a __JSON (left-side) adapter and create a Web API project to gather end-users feedbacks
    - Replace the PoemFileAdapter and CycleThroughPoemsAdapter with a DatabaseAdapter
    - Introduce a new API/Verb for the 1st port: GiveMeLines(int linesCount)

