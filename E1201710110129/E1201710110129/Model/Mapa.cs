using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace E1201710110129.Model
{
    class Mapa
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }

        [MaxLength(100)]
        public string DescripcionLarga { get; set; }

        [MaxLength(30)]
        public string DescripcionCorta { get; set; }



    }
}
