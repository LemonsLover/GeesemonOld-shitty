using System.Collections.Generic;

namespace Geesemon.Database.Models
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual IEnumerable<Chat> Chats { get; set; }
        public virtual IEnumerable<Message> Messages { get; set; }
    }
}
