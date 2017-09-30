using System.Net.Http;
using ConquerTheNetworkApp.Services;
using Xamarin.Android.Net;
using Xamarin.Forms.Internals;

namespace ConquerTheNetworkApp.Droid.Services
{
	[Preserve]
	public class DroidMessageHandlerFactory : INativeMessageHandlerFactory
	{
		public HttpMessageHandler GetNativeHandler()
		{
			return new AndroidClientHandler();
		}
	}
}
