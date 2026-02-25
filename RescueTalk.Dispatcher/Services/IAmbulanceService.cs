using RescueTalk.Dispatcher.DTOs;
using RescueTalk.Dispatcher.Models;

namespace RescueTalk.Dispatcher.Services
{
    public interface IAmbulanceService
    {
        Task<List<Ambulance>> GetAllAsync();
        Task AssignAsync(string code, Guid ambulanceId);
    }
}
