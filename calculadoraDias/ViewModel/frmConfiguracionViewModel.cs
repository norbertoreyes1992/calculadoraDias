using Android.Widget;
using calculadoraDias.Helpers;
using calculadoraDias.Model;
using System;
using System.Diagnostics;

namespace calculadoraDias.ViewModel
{
    public class frmConfiguracionViewModel : BaseViewModel
    {
        #region Propiedades Privadas
        private diasModel _dias;
        #endregion

        #region Propiedades Publicas
        public diasModel dias
        {
            get => _dias;
            set
            {
                _dias = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Comandos
        public command guardarConfiguracionCommand { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public frmConfiguracionViewModel()
        {

            inicializarDias();
            guardarConfiguracionCommand = new command(guardarDatos);

        }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo encargado de acutalizar los datos seleccionados
        /// </summary>
        private void guardarDatos()
        {
            try
            {
                App.SQLiteDB.actualizarDias(dias);
                Toast.MakeText(Android.App.Application.Context, "Datos guardados correctamente", ToastLength.Long).Show();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// Metodo encargado de inicialiar el modelo con lo consultado en la lista
        /// </summary>
        /// <param name="listaDias">lista con los checks</param>
        private void inicializarDias()
        {
            try
            {
                var lista = App.SQLiteDB.obtenerDias().Result;

                if (lista.Count <= 0)
                {
                    App.SQLiteDB.guardarDia(new diasModel
                    {
                        iIdDia = 1,
                        Lunes = false,
                        Martes = false,
                        Miercoles = false,
                        Jueves = false,
                        Viernes = false,
                        Sabado = false,
                        Domingo = false
                    });

                }
                else
                {
                    dias = new diasModel
                    {
                        Lunes = lista[0].Lunes,
                        Martes = lista[0].Martes,
                        Miercoles = lista[0].Miercoles,
                        Jueves = lista[0].Jueves,
                        Viernes = lista[0].Viernes,
                        Sabado = lista[0].Sabado,
                        Domingo = lista[0].Domingo,
                        iIdDia = lista[0].iIdDia
                    };
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        #endregion
    }
}
