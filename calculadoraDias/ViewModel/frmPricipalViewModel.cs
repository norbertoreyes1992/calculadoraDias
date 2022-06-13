using Android.App;
using Android.Widget;
using calculadoraDias.Helpers;
using calculadoraDias.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        private ObservableCollection<string> _dtListaFechas;
        private ObservableCollection<respuestaModel> _respuestaModel;

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

        public ObservableCollection<string> dtListaFechas
        {
            get => _dtListaFechas;
            set
            {
                _dtListaFechas = value;
                OnPropertyChanged();
            }
        }

        public INavigation Navigation { get; set; }

        public ObservableCollection<respuestaModel> respuestaModel
        {
            get => _respuestaModel;
            set
            {
                _respuestaModel = value;
                OnPropertyChanged();
            }
        }
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
            respuestaModel = new ObservableCollection<respuestaModel>();
            calcularDiasCommand = new command(async () => await calcularDias());
            configuracionCommand = new command(async () => await abrirConfiguracion());
            sTotalDias = "Dias";
            dtListaFechas = new ObservableCollection<string>();
            this.Navigation = navigation;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo encargado de calcular los dias entre las fechas seleccionadas
        /// </summary>
        private async Task calcularDias()
        {
            int iTotalDias = 0;
            respuestaModel.Clear();
            if (DateTime.Compare(dtFechaInicio, dtFechaFin) >= 1)
            {
                Toast.MakeText(Android.App.Application.Context, "La fecha inicio no puede ser mayor a la final", ToastLength.Long).Show();
                return;
            }

            //Create my object
            var fechas = new
            {
                fechaa = dtFechaInicio.ToString("yyyy-MM-dd"),
                fechad = dtFechaFin.ToString("yyyy-MM-dd")
            };

            string jsonData = JsonConvert.SerializeObject(fechas);

            var service = new HttpHelper<respuestaModel>();

            var noticiasServicio = await service.getDays(jsonData);
            if (noticiasServicio.ok)
            {
                DateTime dtInicio = dtFechaInicio;
                while (dtInicio <= dtFechaFin)
                {
                    var dia = noticiasServicio.holidays.FirstOrDefault(x => x.date == dtInicio.Date);
                    if (dia != null)
                    {
                        dtListaFechas.Add(dia.name);
                    }
                    dtInicio = dtInicio.AddDays(1);
                    iTotalDias++;
                }
                sTotalDias = iTotalDias > 1 ? iTotalDias.ToString() + " Dias" : iTotalDias.ToString() + " Dia";
            }
            else
            {
                Toast.MakeText(Android.App.Application.Context, noticiasServicio.message, ToastLength.Long).Show();
            }
        }


        /// <summary>
        /// Metodo encargado de abrir el formulario de conifuracion
        /// </summary>
        /// <returns></returns>
        private async Task abrirConfiguracion()
        {
            await Navigation.PushAsync(new View.frmConfiguracion());
        }

        #endregion

    }
}