using ShareSpecial.BusinessEntities;
using System;

namespace ShareSpecial.BusinessEntities
{
    public abstract class BaseEntity : IBaseEntity
    {
        private long? _id;
        private DateTimeOffset _createdOn = DateTimeOffset.Now;
        private string _createdBy = "system";
        private DateTimeOffset _updatedOn = DateTimeOffset.Now;
        private string _updatedBy = "system";
        private bool _isDeleted;
        private byte[] _rowVersion;
        public long? Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public DateTimeOffset CreatedOn
        {
            get { return _createdOn; }
            set { _createdOn = value; }
        }
        public string CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }
        public DateTimeOffset UpdatedOn
        {
            get { return _updatedOn; }
            set { _updatedOn = value; }
        }
        public string UpdatedBy
        {
            get { return _updatedBy; }
            set { _updatedBy = value; }
        }
        public bool IsDeleted
        {
            get { return _isDeleted; }
            set { _isDeleted = value; }
        }
        public byte[] RowVersion
        {
            get
            {
                return _rowVersion;
            }

            set
            {
                _rowVersion = value;
            }
        }
    }
}