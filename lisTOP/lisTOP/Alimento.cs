using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace lisTOP
{
    [Table("Alimentos")]
    public class Alimento
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String TipoRefeicao { get; set; }
        public String Nome { get; set; }
        public String UnidadeMedida { get; set; }
        public String Classe { get; set; }
        public Double Quantidade1600 { get; set; }
        public Double Quantidade2200 { get; set; }
        public Double Quantidade2800 { get; set; }
        public Double QuantidadeMinima { get; set; }
        public Boolean Amendoim { get; set; }
        public Boolean Carboidrato { get; set; }
        public Boolean Gluten { get; set; }
        public Boolean Lactose { get; set; }
        public Boolean Ovo { get; set; }
        public Boolean Proteina { get; set; }
        public Boolean Soja { get; set; }
        public Boolean Vegana { get; set; }
        public Boolean Vegetariana { get; set; }

        public Alimento()
        {
            this.Nome = "";
            this.UnidadeMedida = "";
            this.Classe = "";
            this.Quantidade1600 = 0;
            this.Quantidade2200 = 0;
            this.Quantidade2800 = 0;
            this.QuantidadeMinima = 0;
            this.Amendoim = false;
            this.Carboidrato = false;
            this.Gluten = false;
            this.Lactose = false;
            this.Ovo = false;
            this.Proteina = false;
            this.Soja = false;
            this.Vegana = false;
            this.Vegetariana = false;
        }

        public Alimento(String Nome, String UnidadeMedida, String Classe, double Quantidade1600, double Quantidade2200, double Quantidade2800, double QuantidadeMinima)
        {
            new Alimento();
            this.Nome = Nome;
            this.UnidadeMedida = UnidadeMedida;
            this.Classe = Classe;
            this.Quantidade1600 = Quantidade1600;
            this.Quantidade2200 = Quantidade2200;
            this.QuantidadeMinima = QuantidadeMinima;
            this.Quantidade2800 = Quantidade2800;
        }
    }
}
