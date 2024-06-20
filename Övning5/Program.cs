// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Övning5;

IUI ui = new UI();
var manager = new Manager(ui);

manager.Run();

Console.WriteLine("Github");

/*
 * Unit testing
Testen ska skapas i ett eget testprojekt. Vi begränsar oss till att testa de publika
metoderna i klassen Garage . (Att skriva test för hela applikationen ses som en extra
uppgift om tid finns)
Experimentera gärna med att skriva testen före ni implementerat funktionaliteten!
Använd er sedan ctrl . för att generera era objekt och metoder.
Implementera sen funktionaliteten tills testet går igenom.

Strukturera testen enligt principen.
1. Arrange här sätter ni upp det som ska testas, instansierar objekt och inputs
2. Act här anropar ni metoden som ska testas
3. Assert här kontrollerar ni att ni fått det förväntade resultatet
Tänk även på att namnge testen på ett förklarande sätt. När ett test inte går igenom vill vi
veta vad som inte fungerat enbart genom att se på testmetod namnet.
Exempelvis:
[MethodName_StateUnderTest_ExpectedBehavior]
Public void Sum_NegativeNumberAs1stParam_ExceptionThrown
*/