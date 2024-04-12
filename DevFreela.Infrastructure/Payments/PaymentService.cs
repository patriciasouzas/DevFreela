using DevFreela.Core.DTOs;
using DevFreela.Core.Services;
using System.Text;
using System.Text.Json;

namespace DevFreela.Infrastructure.Payments
{
	public class PaymentService : IPaymentService
	{
		private readonly IMessageBusService _messageBusService;
		private const string QUEUE_NAME = "Payments";
		public PaymentService(IMessageBusService messageBusService)
		{
			_messageBusService = messageBusService;
		}
		public void ProcessPayment(PaymentInfoDto paymentInfDTO)
		{
			//var url = $"{_paymentsBaseUrl}/api/payments";
			var paymentInfoJson = JsonSerializer.Serialize(paymentInfDTO);

			var paymentInfoBytes = Encoding.UTF8.GetBytes(paymentInfoJson);

			_messageBusService.Publish(QUEUE_NAME, paymentInfoBytes);

			/*var paymentInfoContent = new StringContent(
				paymentInfoJson,
				Encoding.UTF8,
				"application/json"
				);

			var httpClient = _httpClientFactory.CreateClient("Payments");

			var response = await httpClient.PostAsync(url, paymentInfoContent);

			return response.IsSuccessStatusCode;*/
		}
	}
}
