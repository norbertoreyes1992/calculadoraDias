using calculadoraDias.Helpers;
using calculadoraDias.Model;

namespace calculadoraDias.ViewModel
{
    public class frmConfiguracionViewModel : BaseViewModel
    {
        #region Propiedades Publicas
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

        public frmConfiguracionViewModel()
        {
            var lista = App.SQLiteDB.obtenerDias().Result;
            //App.SQLiteDB.eliminarDias(lista[0]);
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
                    Domingo = lista[0].Domingo
                };
            }

            guardarConfiguracionCommand = new command(guardarDatos);

        }

        private void guardarDatos()
        {
            App.SQLiteDB.actualizarDias(dias);
        }
    }
}
