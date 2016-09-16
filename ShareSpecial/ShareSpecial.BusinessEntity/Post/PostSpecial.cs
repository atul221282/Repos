using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.BusinessEntities.Post
{
    public class PostSpecial : BaseEntity
    {
        private string _details;
        private long _postedById;
        private long _postSpecialTypeid;
        private DateTimeOffset _createDate;
        private DateTimeOffset _endDate;
        private string _promoCode;
        private bool _isAvailableOnline;

        public string Details
        {
            get { return _details; }
            set { _details = value; }
        }
        public long PostedById
        {
            get { return _postedById; }
            set { _postedById = value; }
        }
        public long PostSpecialTypeId
        {
            get { return _postSpecialTypeid; }
            set { _postSpecialTypeid = value; }
        }
        public DateTimeOffset CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }
        public DateTimeOffset EndDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }
        public string PromoCode
        {
            get { return _promoCode; }
            set { _promoCode = value; }
        }
        public bool IsAvailableOnline
        {
            get { return _isAvailableOnline; }
            set { _isAvailableOnline = value; }
        }


        public virtual Users PostedBy { get; set; }
        public virtual PostSpecialType PostSpecialType { get; set; }


    }
}
