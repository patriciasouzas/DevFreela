﻿using DevFreela.Payments.API.Model;
using DevFreela.Payments.API.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace DevFreela.Payments.API.Consumers
{
	public class ProcessPaymentsConsumer : BackgroundService
	{
		private const string QUEUE = "Payments";
		private readonly IConnection _connection;
		private readonly IModel _channel;
		private readonly IServiceProvider _serviceProvider;
		public ProcessPaymentsConsumer(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;

			var factory = new ConnectionFactory
			{
				HostName = "localhost"
			};
			_connection = factory.CreateConnection();
			_channel = _connection.CreateModel();

			_channel.QueueDeclare(
				queue: QUEUE,
				durable: false,
				exclusive: false,
				autoDelete: false,
				arguments: null);
		}
		protected override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			var consumer = new EventingBasicConsumer(_channel);

			consumer.Received += (sender, eventArgs) =>
			{
				var byteArray = eventArgs.Body.ToArray();
				var paymentsInfoJson = Encoding.UTF8.GetString(byteArray);

				var paymentInfo = JsonSerializer.Deserialize<PaymentInfoInputModel>(paymentsInfoJson);

				ProcessPayment(paymentInfo);

				_channel.BasicAck(eventArgs.DeliveryTag, false);
			};

			_channel.BasicConsume(QUEUE, false, consumer);

			return Task.CompletedTask;
		}

		public void ProcessPayment(PaymentInfoInputModel paymentInfo)
		{
			using (var scope = _serviceProvider.CreateScope())
			{
				var paymentService = scope.ServiceProvider.GetRequiredService<IPaymentService>();

				paymentService.Process(paymentInfo);
			}

		}
	}
}
