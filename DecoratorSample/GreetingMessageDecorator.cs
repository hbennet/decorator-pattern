using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorSample
{
	public class GreetingMessageDecorator : MessageProviderDecoratorBase
	{
		public GreetingMessageDecorator(IMessageProvider messageProvider) : base(messageProvider) { }

		public override string GetMessage()
		{
			return "Hello, your message is: " + base.GetMessage();
		}
	}
}
