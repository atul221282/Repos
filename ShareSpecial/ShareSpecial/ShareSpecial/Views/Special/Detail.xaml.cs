using ShareSpecial.ViewModel.Special;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ShareSpecial.Views.Special
{
    public partial class Detail : ContentPage
    {
        protected readonly ISpecialDetailViewModel vm;
        public Detail(ISpecialDetailViewModel vm)
        {
            this.vm = vm;
            this.BindingContext = this.vm;
            InitializeComponent();
        }
    }
}
