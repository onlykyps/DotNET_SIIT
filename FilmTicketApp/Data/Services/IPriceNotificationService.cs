using FilmTicketApp.Models;

namespace FilmTicketApp.Data.Services
{
    public interface IPriceNotificationService
    {
        Task NotifyPriceUpdateAsync(List<TicketType> updatedTicketTypes);
        Task NotifyPriceUpdateAsync(TicketType updatedTicketType);
    }
}