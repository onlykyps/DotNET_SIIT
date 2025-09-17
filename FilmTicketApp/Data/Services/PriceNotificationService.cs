using FilmTicketApp.Models;

namespace FilmTicketApp.Data.Services
{
    public class PriceNotificationService : IPriceNotificationService
    {
        public PriceNotificationService()
        {
        }

        public async Task NotifyPriceUpdateAsync(List<TicketType> updatedTicketTypes)
        {
            await Task.CompletedTask;
        }

        public async Task NotifyPriceUpdateAsync(TicketType updatedTicketType)
        {
            await NotifyPriceUpdateAsync(new List<TicketType> { updatedTicketType });
        }
    }
}