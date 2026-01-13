using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class GymClass
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        [Range(1, 300)]
        public TimeSpan Duration { get; set; }
        public DateTime EndTime { get { return StartTime + Duration; } }
        public string? Description { get; set; }
        // Navigation property
        public ICollection<ApplicationUserGymClass> AttendingMembers { get; set; }
            = new List<ApplicationUserGymClass>();

    }
}
