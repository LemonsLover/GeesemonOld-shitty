using System;

namespace Geesemon.Database
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
