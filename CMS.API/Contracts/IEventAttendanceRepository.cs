using CMS.API.Entities;

namespace CMS.API.Contracts
{
    public interface IEventAttendanceRepository
    {
        Task<IEnumerable<EventAttendance>> GetEventAttendances();
        Task<EventAttendance> GetEventAttendanceById(int id);
        Task<int> CreateEventAttendance(EventAttendance eventAttendance);
        Task<int> UpdateEventAttendance(EventAttendance eventAttendance);
        Task<int> DeleteEventAttendance(int id);
    }
}
