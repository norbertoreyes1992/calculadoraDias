using System;

namespace calculadoraDias.Model
{
    public class respuestaModel
    {
        public bool ok { get; set; }
        public string message { get; set; }
        public Holiday[] holidays { get; set; }
    }

    public class Holiday
    {
        public Country country { get; set; }
        public DateTime date { get; set; }
        public string _id { get; set; }
        public string name { get; set; }
        public string[] type { get; set; }
    }

    public class Country
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}