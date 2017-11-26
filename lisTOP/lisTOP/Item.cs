using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace lisTOP
{
    [Table("Items")]
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int IdAlimento { get; set; }
        public int IdLista { get; set; }
        public String Nome { get; set; }
        public double Quantidade { get; set; }
        public String UnidadeMedida { get; set; }
        public String Classe { get; set; }

        public Item() { }

        public Item(String nome, Double quantidade, String unidadeMedida, String classe, Int32 IdAlimento)
        {
            this.Nome = nome;
            this.Quantidade = quantidade;
            this.UnidadeMedida = unidadeMedida;
            this.Classe = classe;
            this.IdAlimento = IdAlimento;
        }

        override public String ToString()
        {
            return this.Nome;
        }

        public static List<Item> PegarTodosOsProdutosCafe()
        {
            List<Item> itemsCafe = new List<Item>();

            List<Alimento> alimentos = App.DAUtil.GetAllAlimentosCafe();

            foreach(Alimento alimento in alimentos)
            {
                itemsCafe.Add(new Item(alimento.Nome, alimento.QuantidadeMinima, alimento.UnidadeMedida, alimento.Classe, alimento.Id));
            }

            return itemsCafe;
        }

        public static List<Item> PegarTodosOsProdutosAlmoco()
        {
            List<Item> itemsAlmoco = new List<Item>();

            List<Alimento> alimentos = App.DAUtil.GetAllAlimentosAlmocoJanta();

            foreach (Alimento alimento in alimentos)
            {
                itemsAlmoco.Add(new Item(alimento.Nome, alimento.QuantidadeMinima, alimento.UnidadeMedida, alimento.Classe, alimento.Id));
            }

            return itemsAlmoco;
        }
    }
}
