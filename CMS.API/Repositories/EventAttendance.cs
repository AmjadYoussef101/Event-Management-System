using CMS.API.Contracts;
using CMS.API.Entities;
using CMS.API.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Repositories
{
    public class EventAttendanceRepository : IEventAttendanceRepository
    {
        private readonly DataContext _context;

        public EventAttendanceRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EventAttendance>> GetEventAttendances()
        {
            return await _context.EventAttendances.ToListAsync();
        }

        public async Task<EventAttendance> GetEventAttendanceById(int id)
        {
            return await _context.EventAttendances.FindAsync(id);
        }

        public async Task<int> CreateEventAttendance(EventAttendance eventAttendance)
        {
            try
            {
                _context.EventAttendances.Add(eventAttendance);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> UpdateEventAttendance(EventAttendance eventAttendance)
        {
            try
            {
                var existingEntity = await _context.EventAttendances.FindAsync(eventAttendance.Id);

                if (existingEntity == null)
                    return 0;

                _context.Entry(existingEntity).CurrentValues.SetValues(eventAttendance);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> DeleteEventAttendance(int id)
        {
            try
            {
                var existingEntity = await _context.EventAttendances.FindAsync(id);

                if (existingEntity == null)
                    return 0;

                _context.EventAttendances.Remove(existingEntity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
