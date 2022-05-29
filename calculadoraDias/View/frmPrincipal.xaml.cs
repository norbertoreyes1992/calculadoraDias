using calculadoraDias.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace calculadoraDias.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class frmPrincipal : ContentPage
    {
        frmPricipalViewModel frmPrincipalVM;
        public frmPrincipal()
        {
            InitializeComponent();
            frmPrincipalVM = new frmPricipalViewModel(Navigation);
            this.BindingContext = frmPrincipalVM;
            NavigationPage.SetHasBackButton(this, false);
        }
    }
}