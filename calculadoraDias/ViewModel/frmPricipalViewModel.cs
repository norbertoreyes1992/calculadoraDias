using Android.App;
using Android.Widget;
using calculadoraDias.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace calculadoraDias.ViewModel
{
    public class frmPricipalViewModel : BaseViewModel
    {
        #region Propiedades Privadas
        private DateTime _dtFechaInicio;
        private DateTime _dtFechaFin;
        private string _sTotalDias;
        private ObservableCollection<DateTime> _dtListaFechas;

        #endregion

        #region Propiedades publicas
        public DateTime dtFechaInicio
        {
            get => _dtFechaInicio;
            set
            {
                _dtFechaInicio = value;
                OnPropertyChanged();
            }
        }
        public DateTime dtFechaFin
        {
            get => _dtFechaFin;
            set
            {
                _dtFechaFin = value;
                OnPropertyChanged();
            }
        }

        public string sTotalDias 
        { 
            get => _sTotalDias;
            set 
            {
                _sTotalDias = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<DateTime> dtListaFechas
        {
            get => _dtListaFechas;
            set
            {
                _dtListaFechas = value;
                OnPropertyChanged();
            }
        }

        public INavigation Navigation { get; set; }


        #endregion

        #region Comandos
        public command calcularDiasCommand { get; private set; }
        public command configuracionCommand { get; private set; }

        #endregion

        #region Contructor
        public frmPricipalViewModel(INavigation navigation)
        {
            dtFechaInicio = DateTime.Now;
            dtFechaFin = DateTime.Now;
            calcularDiasCommand = new command(calcularDias);
            configuracionCommand = new command(async () => await abrirConfiguracion());
            sTotalDias = "Dias";
            dtListaFechas = new ObservableCollection<DateTime>();
            this.Navigation = navigation;
        }

        #endregion

        #region Metodos
        private void calcularDias()
        {
            int iTotalDias = 0;
            dtListaFechas.Clear();
            if (DateTime.Compare(dtFechaInicio, dtFechaFin) >= 1)
            {
                Toast.MakeText(Android.App.Application.Context, "La fecha inicio no puede ser mayor a la final", ToastLength.Long).Show();
                return;
            }

            DateTime dtInicio = dtFechaInicio;
            while (dtInicio <= dtFechaFin)
            {
                dtListaFechas.Add(dtInicio);
                dtInicio = dtInicio.AddDays(1);
                iTotalDias++;
            }
            sTotalDias = iTotalDias > 1 ? iTotalDias.ToString() + " Dias" : iTotalDias.ToString() + " Dia";
        }

        private async Task abrirConfiguracion()
        {
            await Navigation.PushAsync(new View.frmConfiguracion());
        }

        #endregion

    }
}