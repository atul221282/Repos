using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Model
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
