using System.Net.Http;
using ConquerTheNetworkApp.Services;

namespace ConquerTheNetworkApp.iOS.Services
{
	public class iOSMessageHandlerFactory : INativeMessageHandlerFactory
	{
		public HttpMessageHandler GetNativeHandler()
		{
			return new NSUrlSessionHandler();
		}
	}
}
