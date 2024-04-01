using DevFreela.Core.DTOs;
using DevFreela.Core.Services;

namespace DevFreela.Infrastructure.Payments
{
	public class PaymentService : IPaymentService
	{
		public Task<bool> ProcessPayment(PaymentInfoDto paymentInfDTO)
		{
			// TODO lógica de pagamento com Gateway de pagamento
			return Task.FromResult(true);
		}
	}
}
