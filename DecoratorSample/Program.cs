using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorSample
{
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
}
