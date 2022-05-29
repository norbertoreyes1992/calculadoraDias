using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace calculadoraDias.Model
{
    public class diasModel
    {
        [PrimaryKey,AutoIncrement]
        public int iIdDia { get; set; }
        public string sDia { get; set; }
        public bool bEstatus { get; set; }
    }
}
