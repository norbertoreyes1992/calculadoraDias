﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace calculadoraDias.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class frmPrincipal : ContentPage
    {
        public frmPrincipal()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }
    }
}