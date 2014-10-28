using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorSample
{
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
}
