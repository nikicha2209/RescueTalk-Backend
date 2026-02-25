using Microsoft.EntityFrameworkCore;
using RescueTalk.Dispatcher.Data;
using RescueTalk.Dispatcher.DTOs;
using RescueTalk.Dispatcher.Models;
using System.Globalization;

namespace RescueTalk.Dispatcher.Services
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Основна бизнес логика за управление на спешни повиквания (инциденти).
    /// </summary>
    public class IncidentService : IIncidentService
    {
        private readonly RescueTalkDbContext _context;

        public IncidentService(RescueTalkDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Извлича всички активни инциденти (статус различен от Completed).
        /// </summary>
        public async Task<List<Incident>> GetAllAsync()
        {
            return await _context.Incidents
                .Include(i => i.Ambulance)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Генерира нов инцидент с уникален за системата код.
        /// </summary>
        public async Task<Incident> CreateAsync(CreateIncidentDto dto)
        {
            var incident = new Incident
            {
                Id = Guid.NewGuid(),
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                Code = await GenerateUniqueCode(),
                Status = "Pending",
                IsActive = true
            };

            _context.Incidents.Add(incident);
            await _context.SaveChangesAsync();
            return incident;
        }

        /// <summary>
        /// Приключване на мисия и освобождаване на ресурса (линейката).
        /// </summary>
        public async Task CompleteAsync(string code)
        {
            var incident = await _context.Incidents
                .Include(i => i.Ambulance)
                .FirstOrDefaultAsync(i => i.Code == code);

            if (incident == null) throw new KeyNotFoundException("Инцидентът не е намерен.");

            incident.Status = "Completed";
            incident.IsActive = false;

            if (incident.Ambulance != null)
            {
                incident.Ambulance.IsAvailable = true;
                incident.AmbulanceId = null; 
            }

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Помощен метод за генериране на уникален код (RT-XXXXXX).
        /// </summary>
        private async Task<string> GenerateUniqueCode()
        {
            var random = new Random();
            string code;
            do
            {
                code = $"RT-{random.Next(100000, 999999)}";
            } while (await _context.Incidents.AnyAsync(i => i.Code == code));
            return code;
        }
    }
}
