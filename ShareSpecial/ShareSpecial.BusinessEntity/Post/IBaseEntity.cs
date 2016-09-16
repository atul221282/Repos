using System;

namespace PostAnything.BusinessEntities
{
    public interface IBaseEntity
    {
        long? Id { get; set; }

        DateTimeOffset CreatedOn { get; set; }

        string CreatedBy { get; set; }

        DateTimeOffset UpdatedOn { get; set; }

        string UpdatedBy { get; set; }

        bool IsDeleted { get; set; }

        byte[] RowVersion { get; set; }
    }
}