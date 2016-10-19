using ShareSpecial.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpecial.ViewModel.Special
{
    public class SpecialViewModel : ISpecialViewModel
    {
        private readonly ISpecialService Special;

        public SpecialViewModel(ISpecialService special)
        {
            Special = special;
            
        }

        public string Name { get; set; }

    }
}
