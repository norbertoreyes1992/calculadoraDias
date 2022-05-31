using SQLite;

namespace calculadoraDias.Model
{
    public class diasModel
    {
        [PrimaryKey,AutoIncrement]
        public int iIdDia { get; set; }
        public bool Lunes { get; set; }
        public bool Martes { get; set; }
        public bool Miercoles { get; set; }
        public bool Jueves { get; set; }
        public bool Viernes { get; set; }
        public bool Sabado { get; set; }
        public bool Domingo { get; set; }
    }
}
