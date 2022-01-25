using System.Collections.Generic;

namespace Geesemon.Database.Models
{
    public class Chat : BaseEntity
    {
        public string Name { get; set; }
        public Type Type { get; set; }

        public virtual IEnumerable<Message> Messages { get; set; }
        public virtual IEnumerable<User> Users { get; set; }
    }

    public enum Type
    {
        Dialog,
        Group,
    }
}
