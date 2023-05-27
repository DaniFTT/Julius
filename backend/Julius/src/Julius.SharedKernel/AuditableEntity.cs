using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Julius.SharedKernel
{
    public abstract class AuditableEntity
    {
        public DateTimeOffset CreatedAt { get; private set; }
        public DateTimeOffset LastUpdatedAt { get; private set; }
        public bool IsDeleted { get; private set; }

        public AuditableEntity()
        {
            CreatedAt = DateTimeOffset.UtcNow;
            LastUpdatedAt = DateTimeOffset.UtcNow;
            IsDeleted = false;
        }

        public void MarkAsUpdated()
        {
            LastUpdatedAt = DateTimeOffset.UtcNow;
        }

        public void MarkAsDeleted()
        {
            IsDeleted = true;
        }
    }
}
