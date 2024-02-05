using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.API.Entities
{
    [Table("SponsorEvents")]
    public class SponsorEvent
    {
        [Key]
        public int Id { get; set; }
        public int SponsorId { get; set; }
        public Sponsor Sponsor { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
