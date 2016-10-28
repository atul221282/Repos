using ShareSpecial.BusinessEntities.Post;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShareSpecial.ViewModel
{
    public interface IMainPageViewModel
    {
        Command GetSpecialCommand { get; }

        ObservableCollection<PostSpecial> PostSpecials { get; set; }

        //Task<List<PostSpecial>> GetSpecials(double longitude, double latitude, int distance);
    }
}
