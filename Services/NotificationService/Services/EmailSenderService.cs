
using RabbitMQService.Interfaces;
using Newtonsoft.Json;
using BlobStorageService;
using BlobStorageService.Helpers;
using Azure.Communication.Email;
using Azure;

namespace NotificationServices.Services
{
    public class EmailSenderService: IMessageProcessor
    {      
        private readonly ILogger<EmailSenderService> _logger;
        private readonly IBlobStorageService _blobStorageService;
        public EmailSenderService(ILogger<EmailSenderService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task ProcessMessageAsync(string message)
        {
            string connectionString = "endpoint=https://thesis-communication-services.communication.azure.com/;accesskey=9t9Wu4UmFcRqvqdJ8cxZ8qHTk/vzojheKWB30yP0HXlOUtrB3DgYGX4lU0nLIFHQxN+82wxXSXAhVSSvd0jXSw==";
            EmailClient emailClient = new EmailClient(connectionString);
            var subject = "Curriculum Validation Success";
            var htmlContent = $"<html><body><h1>Curriculum Validation </h1><br/><h4>{message}</h4><p>This mail was sent via Curriculum Management System!!</p></body></html>";
            var sender = "SystemNotification@a3b20cd2-6b89-4893-af06-61cb3037a3f7.azurecomm.net";
            var recipient = "hatiendat.dev@gmail.com";
            try
            {
                _logger.LogInformation("Sending email...");
                EmailSendOperation emailSendOperation = await emailClient.SendAsync(
                    Azure.WaitUntil.Completed,
                    sender,
                    recipient,
                    subject,
                    htmlContent);
                EmailSendResult statusMonitor = emailSendOperation.Value;

                _logger.LogInformation($"Email Sent. Status = {emailSendOperation.Value.Status}");

                /// Get the OperationId so that it can be used for tracking the message for troubleshooting
                string operationId = emailSendOperation.Id;
                _logger.LogInformation($"Email operation id = {operationId}");
            }
            catch (RequestFailedException ex)
            {
                /// OperationID is contained in the exception message and can be used for troubleshooting purposes
                _logger.LogError($"Email send operation failed with error code: {ex.ErrorCode}, message: {ex.Message}");
            }

        }
    }
}
    