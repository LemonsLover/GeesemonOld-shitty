using System.Collections.Generic;

namespace Geesemon.Database.Models
{
    public class Message : BaseEntity
    {
        public string Text { get; set; }

        public virtual int ChatId { get; set; }
        public virtual Chat Chat { get; set; }
        public virtual int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
