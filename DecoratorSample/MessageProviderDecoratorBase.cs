using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorSample
{
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
}
