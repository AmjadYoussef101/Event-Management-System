using CMS.API.Entities;

namespace CMS.API.Contracts
{
    public interface IPartnerEventRepository
    {
        Task<IEnumerable<PartnerEvent>> GetPartnerEvents();
        Task<PartnerEvent> GetPartnerEventById(int id);
        Task<int> CreatePartnerEvent(PartnerEvent eventPartner);
        Task<int> UpdatePartnerEvent(PartnerEvent eventPartner);
        Task<int> DeletePartnerEvent(int id);
    }
}
