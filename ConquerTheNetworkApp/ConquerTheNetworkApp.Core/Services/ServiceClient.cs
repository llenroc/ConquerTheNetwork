using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ConquerTheNetworkApp.Data;
using Refit;

namespace ConquerTheNetworkApp.Services
{
	public class ServiceClient
	{
		public static string ApiBaseAddress = "http://conquerthenetworksampleservice.azurewebsites.net";

		private IConferenceApi _client;
		private static INativeMessageHandlerFactory _factory;

		public static void Init(INativeMessageHandlerFactory factory)
		{
			_factory = factory;
		}

		public ServiceClient()
		{
			var nativeClient = new HttpClient(_factory.GetNativeHandler())
			{
				BaseAddress = new System.Uri(ApiBaseAddress)
			};

			_client = RestService.For<IConferenceApi>(nativeClient);
		}

		public Task<List<City>> GetCities()
		{
			return _client.GetCities();
		}

		public async Task<Schedule> GetScheduleForCity(string id)
		{
			try
			{
				return await _client.GetScheduleForCity(id);
			}
			catch (ApiException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
			{
				return null;
			}
		}

		public Task SendRating(double rating)
		{
			return _client.Rate(rating);
		}
	}
}
