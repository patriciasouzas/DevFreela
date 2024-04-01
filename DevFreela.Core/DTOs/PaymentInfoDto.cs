namespace DevFreela.Core.DTOs
{
	public class PaymentInfoDto
	{
		public PaymentInfoDto(int id, string creditCardNumber, string cvv, string expiresAt, string fullName)
		{
			Id = id;
			CreditCardNumber = creditCardNumber;
			Cvv = cvv;
			ExpiresAt = expiresAt;
			FullName = fullName;
		}

		public int Id { get; set; }
		public string CreditCardNumber { get; set; }
		public string Cvv { get; set; }
		public string ExpiresAt { get; set; }
		public string FullName { get; set; }
	}
}
