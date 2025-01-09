using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Maintenance
    {
        public int Id { get; set; }

        public string Observation { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        public DateTime CreatedAt { get; set; }

        private DateTime scheduleAt;
        public DateTime ScheduleAt
        {
            get { return scheduleAt; }
            set { scheduleAt = DateTime.SpecifyKind(value, DateTimeKind.Utc); }
        }

        public Maintenance()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
