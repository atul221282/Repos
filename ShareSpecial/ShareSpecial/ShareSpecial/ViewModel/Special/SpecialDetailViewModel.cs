using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareSpecial.Helpers;
using ShareSpecial.BusinessEntities.Post;

namespace ShareSpecial.ViewModel.Special
{
    public class SpecialDetailViewModel : BaseViewModel, ISpecialDetailViewModel
    {
        public SpecialDetailViewModel(INavigationService navigation) : base(navigation)
        {
        }

        private PostSpecial _special;

        public PostSpecial Special
        {
            get { return _special; }
            set { SetProperty(ref _special, value); }
        }

    }
}
