using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CMS.API.Entities
{
    [Table("Events")]
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }

        [NotMapped] 
        public IFormFile Image { get; set; }
        public ICollection<Planner> Planners { get; set; }
        public ICollection<EventAttendance> Attendances { get; set; }
        public ICollection<PartnerEvent> PartnerEvents { get; set; }
        public ICollection<SponsorEvent> SponsorEvents { get; set; }
        public ICollection<EventCategory> EventCategories { get; set; }
        public ICollection<Presentation> Presentations { get; set; }
    }
}
