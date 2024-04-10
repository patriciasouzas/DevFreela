using DevFreela.Payments.API.Model;

namespace DevFreela.Payments.API.Services
{
	public interface IPaymentService
	{
		Task<bool> Process(PaymentInfoInputModel paymentInfoInputModel);
	}
}
