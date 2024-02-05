using CMS.API.Contracts;
using CMS.API.Entities;
using CMS.API.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Repositories
{
    public class EventCategoryRepository : IEventCategoryRepository
    {
        private readonly DataContext _context;

        public EventCategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EventCategory>> GetEventCategories()
        {
            return await _context.EventCategories.ToListAsync();
        }

        public async Task<EventCategory> GetEventCategoryById(int id)
        {
            return await _context.EventCategories.FindAsync(id);
        }

        public async Task<int> CreateEventCategory(EventCategory eventCategory)
        {
            try
            {
                _context.EventCategories.Add(eventCategory);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> UpdateEventCategory(EventCategory eventCategory)
        {
            try
            {
                var existingEntity = await _context.EventCategories.FindAsync(eventCategory.Id);

                if (existingEntity == null)
                    return 0;

                _context.Entry(existingEntity).CurrentValues.SetValues(eventCategory);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> DeleteEventCategory(int id)
        {
            try
            {
                var existingEntity = await _context.EventCategories.FindAsync(id);

                if (existingEntity == null)
                    return 0;

                _context.EventCategories.Remove(existingEntity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
