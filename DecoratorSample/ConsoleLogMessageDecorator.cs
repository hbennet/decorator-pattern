using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorSample
{
	public class ConsoleLogMessageDecorator : MessageProviderDecoratorBase
	{
		public ConsoleLogMessageDecorator(IMessageProvider messageProvider) : base(messageProvider) { }

		public override string GetMessage()
		{
			string message = base.GetMessage();
			
			Console.WriteLine(Environment.NewLine + "LOG: {0}" + Environment.NewLine, message);  // simulate log framework

			return message;
		}
	}
}
