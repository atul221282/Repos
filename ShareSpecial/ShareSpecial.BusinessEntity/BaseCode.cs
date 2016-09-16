using ShareSpecial.BusinessEntities.Interfaces;

namespace ShareSpecial.BusinessEntities
{
    public class BaseCode : BaseEntity, IBaseCode
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }


}