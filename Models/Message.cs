using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace VideoStreamingService.Models
{
    public class Message
    {
        [Required(ErrorMessage = "Message cannot be empty")]
        [StringLength(20000, ErrorMessage = "Maximum length is 20000")]
        public string Content { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        [ForeignKey(nameof(SenderId))]
        public long SenderId { get; set; }
        public User Sender { get; set; }
        [ForeignKey(nameof(ChatId))]
        public long ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}
