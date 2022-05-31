using calculadoraDias.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace calculadoraDias.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class frmConfiguracion : ContentPage
    {
        frmConfiguracionViewModel confViewModel;
        public frmConfiguracion()
        {
            InitializeComponent();
            confViewModel = new frmConfiguracionViewModel();
            this.BindingContext = confViewModel;
        }
    }
}