using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace lisTOP
{
    [Table("Listas")]
    public class Lista
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String nomeLista { get; set; }
        public DateTime dataCriacao { get; set; }

        [Ignore]
        public List<Item> compras { get; set; }
    }
}
