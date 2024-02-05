using CMS.API.Entities;

namespace CMS.API.Contracts
{
    public interface ISponsorEventRepository
    {
        Task<IEnumerable<SponsorEvent>> GetSponsorEvents();
        Task<SponsorEvent> GetSponsorEventById(int id);
        Task<int> CreateSponsorEvent(SponsorEvent eventSponsor);
        Task<int> UpdateSponsorEvent(SponsorEvent eventSponsor);
        Task<int> DeleteSponsorEvent(int id);
    }
}
