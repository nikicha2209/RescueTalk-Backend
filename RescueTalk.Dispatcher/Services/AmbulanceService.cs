using Microsoft.EntityFrameworkCore;
using RescueTalk.Dispatcher.Data;
using RescueTalk.Dispatcher.DTOs;
using RescueTalk.Dispatcher.Models;

namespace RescueTalk.Dispatcher.Services
{
    /// <summary>
    /// Услуга за управление на ресурсите (линейки).
    /// Отговаря за жизнения цикъл на линейките и тяхната наличност.
    /// </summary>
    public class AmbulanceService : IAmbulanceService
    {
        private readonly RescueTalkDbContext _context;

        public AmbulanceService(RescueTalkDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Извлича списък на всички регистрирани линейки.
        /// Използва AsNoTracking за оптимизация на паметта при четене.
        /// </summary>
        public async Task<List<Ambulance>> GetAllAsync()
        {
            return await _context.Ambulances
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Ръчно свързване на конкретна линейка с инцидент.
        /// Реализира бизнес логика за проверка на наличност.
        /// </summary>
        public async Task AssignAsync(string code, Guid ambulanceId)
        {
            var incident = await _context.Incidents
                .FirstOrDefaultAsync(i => i.Code == code);

            var ambulance = await _context.Ambulances
                .FirstOrDefaultAsync(a => a.Id == ambulanceId);

            if (incident == null || ambulance == null)
                throw new KeyNotFoundException("Търсеният инцидент или линейка не съществува.");

            if (!ambulance.IsAvailable)
                throw new InvalidOperationException("Избраната линейка вече е заета.");

            incident.AmbulanceId = ambulanceId;
            incident.Status = "Assigned";
            ambulance.IsAvailable = false;

            await _context.SaveChangesAsync();
        }
    }
}
