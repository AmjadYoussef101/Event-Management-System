using CMS.API.Entities;

namespace CMS.API.Contracts
{
    public interface IEventCategoryRepository
    {
        Task<IEnumerable<EventCategory>> GetEventCategories();
        Task<EventCategory> GetEventCategoryById(int id);
        Task<int> CreateEventCategory(EventCategory eventCategory);
        Task<int> UpdateEventCategory(EventCategory eventCategory);
        Task<int> DeleteEventCategory(int id);
    }
}
