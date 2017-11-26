using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;

namespace lisTOP
{
    [Table("Usuarios")]
    public class Usuario
    {
        [PrimaryKey]
        public String Username { get; set; }
        public Boolean Mulher { get; set; }
        public Boolean Atleta { get; set; }
        public int FaixaEtaria { get; set; }
   
        public Boolean Amendoim { get; set; }
        public Boolean Carboidrato { get; set; }
        public Boolean Glutem { get; set; }
        public Boolean Lactose { get; set; }
        public Boolean Ovo { get; set; }
        public Boolean Proteina { get; set; }
        public Boolean Soja { get; set; }
        public Boolean Vegano { get; set; }
        public Boolean Vegetariano { get; set; }

        public Boolean Achocolatado { get; set; }
        public Boolean Aves { get; set; }
        public Boolean Bolos { get; set; }
        public Boolean Cafe { get; set; }
        public Boolean CarneBovina { get; set; }
        public Boolean CarneSuina { get; set; }
        public Boolean Cereais { get; set; }
        public Boolean CereaisMatinais { get; set; }
        public Boolean Chas { get; set; }
        public Boolean Embutidos { get; set; }
        public Boolean Especiarias { get; set; }
        public Boolean Frios { get; set; }
        public Boolean Frutas { get; set; }
        public Boolean FrutosDoMar { get; set; }
        public Boolean Graos { get; set; }
        public Boolean Guloseimas { get; set; }
        public Boolean Hortalica { get; set; }
        public Boolean Iogurte { get; set; }
        public Boolean Legumes { get; set; }
        public Boolean Leite { get; set; }
        public Boolean Massas { get; set; }
        public Boolean Ovos { get; set; }
        public Boolean Paes { get; set; }
        public Boolean Peixes { get; set; }
        public Boolean Suco { get; set; }


        public Usuario()
        {
            this.Username = "";
            this.Atleta = false;
            this.FaixaEtaria = 3;
            this.Mulher = true;

            Amendoim = false;
            Carboidrato = false;
            Glutem = false;
            Lactose = false;
            Ovo = false;
            Proteina = false;
            Soja = false;
            Vegano = false;
            Vegetariano = false;

            Achocolatado = true;
            Aves = true;
            Bolos = true;
            Cafe = true;
            CarneBovina = true;
            CarneSuina = true;
            Cereais = true;
            CereaisMatinais = true;
            Chas = true;
            Embutidos = true;
            Especiarias = true;
            Frios = true;
            Frutas = true;
            FrutosDoMar = true;
            Graos = true;
            Guloseimas = true;
            Hortalica = true;
            Iogurte = true;
            Legumes = true;
            Leite = true;
            Massas = true;
            Ovos = true;
            Paes = true;
            Peixes = true;
        }
    }
}
