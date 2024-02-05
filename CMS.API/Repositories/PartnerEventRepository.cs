using CMS.API.Contracts;
using CMS.API.Entities;
using CMS.API.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Repositories
{
    public class PartnerEventRepository : IPartnerEventRepository
    {
        private readonly DataContext _context;

        public PartnerEventRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PartnerEvent>> GetPartnerEvents()
        {
            return await _context.PartnerEvents.ToListAsync();
        }

        public async Task<PartnerEvent> GetPartnerEventById(int id)
        {
            return await _context.PartnerEvents.FindAsync(id);
        }

        public async Task<int> CreatePartnerEvent(PartnerEvent partnerEvent)
        {
            try
            {
                _context.PartnerEvents.Add(partnerEvent);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> UpdatePartnerEvent(PartnerEvent partnerEvent)
        {
            try
            {
                var existingEntity = await _context.PartnerEvents.FindAsync(partnerEvent.Id);

                if (existingEntity == null)
                    return 0;

                _context.Entry(existingEntity).CurrentValues.SetValues(partnerEvent);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> DeletePartnerEvent(int id)
        {
            try
            {
                var existingEntity = await _context.PartnerEvents.FindAsync(id);

                if (existingEntity == null)
                    return 0;

                _context.PartnerEvents.Remove(existingEntity);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
