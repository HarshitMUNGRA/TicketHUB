using Microsoft.AspNetCore.Mvc;
using Azure.Storage.Queues;
using System.Text.Json; // For JSON serialization
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TicketHUB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ILogger<TicketsController> logger;
        private readonly IConfiguration _configuration;

        // Constructor to inject IConfiguration
        public TicketsController(IConfiguration configuration, ILogger<TicketsController> logger)
        {
            _configuration = configuration;
            this.logger = logger;
        }

        // Connection string and queue name for Azure Storage Queue
        private readonly string _queueName = "tickets";

        [HttpPost]
        public async Task<IActionResult> PurchaseTicket([FromBody] TicketPurchase ticketPurchase)
        {
            if (ticketPurchase == null)
            {
                return BadRequest("Invalid purchase data.");
            }

            // Get connection string from appsettings.json or secrets.json
            string? connectionString = _configuration["AzureStorageConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
            {
                return BadRequest("An error was encountered. Connection string is missing.");
            }

            try
            {
                // Create a QueueClient instance
                var queueClient = new QueueClient(connectionString, _queueName);

                // Serialize the object to JSON
                string message = JsonSerializer.Serialize(ticketPurchase);

                // Send the serialized message to the Azure Storage Queue
                await queueClient.SendMessageAsync(message);

                return Ok("Ticket purchase processed successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception
                logger.LogError(ex, "An error occurred while processing the ticket purchase.");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
