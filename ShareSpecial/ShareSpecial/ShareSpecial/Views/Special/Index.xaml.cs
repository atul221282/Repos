﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ShareSpecial.Views.Special
{
    public partial class Index : ContentPage
    {
        public Index()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            //NavigationController.SetNavigationBarHidden(true, true);
            InitializeComponent();
        }
    }
}
