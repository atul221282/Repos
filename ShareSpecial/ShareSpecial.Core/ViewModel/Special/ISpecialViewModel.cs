using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.Core.ViewModel.Special
{
    public interface ISpecialViewModel
    {
        string Name { get; set; }

        string GetName();
    }
}
