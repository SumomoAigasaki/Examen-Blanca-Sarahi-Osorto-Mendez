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
        public string Latitud { get; set; }
        public string Longitud { get; set; }

        [MaxLength(100)]
        public string DescripcionLarga { get; set; }

        [MaxLength(30)]
        public string DescripcionCorta { get; set; }



    }
}
