Decorator Pattern
=================
The decorator pattern is used to extend the functionality of an object, similar to inheritance. What sets the decorator pattern apart is the pattern can be used to dynamically extend the functionality of an object without requiring all instances of that object to include the extended functionality. In this way, the functionality can be added or removed at run-time based on user interactions or as the result of a business rule.
While examining the decorator pattern we see it consists of an interface, a concrete implementation, an abstract implementation forming the decorator base, and the actual decorator classes. The goal of the pattern is to provide the ability to wrap the concrete implementation with the decorator classes and provide new and/or differing functionality from the original object.
Looking at an example where there is a MessageProvider class containing a single method that returns a message, we will see how the decorator can be used .
First , we need an interface and concrete implementation that returns the message passed to the constructor.
```cs
public interface IMessageProvider
{
    string GetMessage();
}
public class MessageProvider : IMessageProvider
{
    private string _message;

    public MessageProvider(string message)
    {
        _message = message;
    }

    public string GetMessage()
    {
        return _message;
    }
}
```

With the concrete classes in place, we can create the decorator hierarchy to extend the functionality of an IMessageProvider class. We will create two decorators, the first inserts text before the message in the MessageProvider, and the second simulates logging to the console by writing out an IMessageProvider's message before returning the message to the caller. The decorator hierarchy consists of an abstract base class specifying that an instance implementing IMessageProvider (described above) needs to be passed into the constructor. The IMessageProvider instance is then stored in a variable and a base implementation is created that acts as a pass-through to the stored IMessageProvider.
```cs
public abstract class MessageProviderDecoratorBase : IMessageProvider
{
    protected IMessageProvider _messageProvider;

    protected MessageProviderDecoratorBase(IMessageProvider messageProvider)
    {
        _messageProvider = messageProvider;
    }

    public virtual string GetMessage()
    {
        return _messageProvider.GetMessage();
    }
}
```

Having created the decorator base class, we can look at the first of the decorators. The GreetingMessageDecorator is a simple decorator that takes in an IMessageProvider and adds a simple greeting to the message returned from calling GetMessage. The purpose of this decorator is to demonstrate how the decorator can add functionality to an object that implements IMessageProvider.
```cs
public class GreetingMessageDecorator : MessageProviderDecoratorBase
{
    public GreetingMessageDecorator(IMessageProvider messageProvider) : base(messageProvider)
    { }

    public override string GetMessage()
    {
        return "Hello, your message is: " + base.GetMessage();
    }
}
```

The second decorator in the sample application is the ConsoleLogMessageDecorator. This decorator performs an action on the IMessageProvider it is was provided during construction before eventually returning the result of the GetMessage method to the caller. The action taken is a simulated log of GetMessage's result written to the console. As simple as this action is, it could be extended to a timer wrapping the call to the IMessageProvider's method, special handling, or a before/after type of action.
```cs
public class ConsoleLogMessageDecorator : MessageProviderDecoratorBase
{
    public ConsoleLogMessageDecorator(IMessageProvider messageProvider) : base(messageProvider)
    { }

    public override string GetMessage()
    {
        string message = base.GetMessage();

        Console.WriteLine(Environment.NewLine + "LOG: {0}" + Environment.NewLine, message);

        return message;
    }
}
```

Finally, we have a simple driver application. The driver builds up a MessageProvider and then creates the decorators, displaying the result of the GetMessage call in each version. Note, the ConsoleLogMessageDecorator takes as input the GreetingMessageDecorator, prints it to the screen as a log message, and returns the chained results of each decorator performing it's action. The output demonstrates how the decorators have affected/interacted with the object being decorated, and, in the case of the ConsoleLogMessageDecorator, how chaining decorators works.
```cs
class Program
{
    static void Main(string[] args)
    {
        IMessageProvider messageProvider = new MessageProvider("Sample message");

        Console.WriteLine(messageProvider.GetMessage());

        IMessageProvider greeting = new GreetingMessageDecorator(messageProvider);

        Console.WriteLine(greeting.GetMessage());

        IMessageProvider logDecorator = new ConsoleLogMessageDecorator(greeting);

        Console.WriteLine(logDecorator.GetMessage());
    }
}
``` 

Output:

![Code Output][output]

Although the example presented is simple, the decorator can be used to implement complex before/ after actions by chaining operations in multiple decorators. One could add timing, logging, and transactions to the same object simply by creating the appropriate decorators and adding them in a chain at runtime. A business rule could determine that a special row needs inserted in a database marking an entity in some way and a decorator adding the needed functionality could be added to the object when the rule is triggered, changing the course of action for the object in question.

[output]: https://github.com/hbennet/decorator-pattern/decorator-pattern.png
