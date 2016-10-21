using ShareSpecial.BusinessEntities.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.ViewModel
{
    public interface IMainPageViewModel
    {
        IEnumerable<PostSpecial> PostSpecials { get; set; }

        Task LoadSpecials();
    }
}
