using Microsoft.EntityFrameworkCore;
using RescueTalk.Dispatcher.DTOs;
using RescueTalk.Dispatcher.Models;
using System.Threading.Tasks;

namespace RescueTalk.Dispatcher.Services
{

    public interface IIncidentService
    {
        Task<List<Incident>> GetAllAsync();
        Task<Incident> CreateAsync(CreateIncidentDto dto);
        Task CompleteAsync(string code);
        
    }
}

