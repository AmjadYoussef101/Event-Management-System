using CMS.API.Contracts;
using CMS.API.Entities;
using CMS.API.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Repositories
{
    public class SponsorEventRepository : ISponsorEventRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<SponsorEventRepository> _logger;

        public SponsorEventRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SponsorEvent>> GetSponsorEvents()
        {
            return await _context.SponsorEvents.ToListAsync();
        }

        public async Task<SponsorEvent> GetSponsorEventById(int id)
        {
            return await _context.SponsorEvents.FindAsync(id);
        }

        public async Task<int> CreateSponsorEvent(SponsorEvent sponsorEvent)
        {
            try
            {
                _context.SponsorEvents.Add(sponsorEvent);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> UpdateSponsorEvent(SponsorEvent sponsorEvent)
        {
            try
            {
                var existingEntity = await _context.SponsorEvents.FindAsync(sponsorEvent.Id);

                if (existingEntity == null)
                    return 0;

                _context.Entry(existingEntity).CurrentValues.SetValues(sponsorEvent);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> DeleteSponsorEvent(int id)
        {
            try
            {
                var existingEntity = await _context.SponsorEvents.FindAsync(id);

                if (existingEntity == null)
                    return 0;

                _context.SponsorEvents.Remove(existingEntity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
