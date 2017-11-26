using System;
using System.Collections.Generic;
using System.Text;

namespace lisTOP
{
    public class Restricao
    {
        public String NomeRestricao;
        public Boolean Ativo;

        public Restricao(String NomeRestricao)
        {
            this.NomeRestricao = NomeRestricao;
            this.Ativo = false;
        }

        public static List<Restricao> PegarTodasRestricoes()
        {
            List<Restricao> restricoes = new List<Restricao>();

            restricoes.Add(new Restricao("Amendoim"));
            restricoes.Add(new Restricao("Carboidrato"));
            restricoes.Add(new Restricao("Glutém"));
            restricoes.Add(new Restricao("Lactose"));
            restricoes.Add(new Restricao("Ovo"));
            restricoes.Add(new Restricao("Proteína"));
            restricoes.Add(new Restricao("Soja"));
            restricoes.Add(new Restricao("Vegano"));
            restricoes.Add(new Restricao("Vegetariano"));

            return restricoes;
        }

        public static List<Restricao> PegarTodasPreferencias()
        {
            List<Restricao> preferencias = new List<Restricao>();

            preferencias.Add(new Restricao("Achocolatado"));
            preferencias[preferencias.Count - 1].Ativo = true;
            preferencias.Add(new Restricao("Aves"));
            preferencias[preferencias.Count - 1].Ativo = true;
            preferencias.Add(new Restricao("Bolos"));
            preferencias[preferencias.Count - 1].Ativo = true;
            preferencias.Add(new Restricao("Café"));
            preferencias[preferencias.Count - 1].Ativo = true;
            preferencias.Add(new Restricao("Carne Bovina"));
            preferencias[preferencias.Count - 1].Ativo = true;
            preferencias.Add(new Restricao("Carne Suína"));
            preferencias[preferencias.Count - 1].Ativo = true;
            preferencias.Add(new Restricao("Cereais"));
            preferencias[preferencias.Count - 1].Ativo = true;
            preferencias.Add(new Restricao("Cereais Matinais"));
            preferencias[preferencias.Count - 1].Ativo = true;
            preferencias.Add(new Restricao("Chás"));
            preferencias[preferencias.Count - 1].Ativo = true;
            preferencias.Add(new Restricao("Embutidos"));
            preferencias[preferencias.Count - 1].Ativo = true;
            preferencias.Add(new Restricao("Especiarias"));
            preferencias[preferencias.Count - 1].Ativo = true;
            preferencias.Add(new Restricao("Frios"));
            preferencias[preferencias.Count - 1].Ativo = true;
            preferencias.Add(new Restricao("Frutas"));
            preferencias[preferencias.Count - 1].Ativo = true;
            preferencias.Add(new Restricao("Frutos Do Mar"));
            preferencias[preferencias.Count - 1].Ativo = true;
            preferencias.Add(new Restricao("Grãos"));
            preferencias[preferencias.Count - 1].Ativo = true;
            preferencias.Add(new Restricao("Guloseimas"));
            preferencias[preferencias.Count - 1].Ativo = true;
            preferencias.Add(new Restricao("Hortalicas"));
            preferencias[preferencias.Count - 1].Ativo = true;
            preferencias.Add(new Restricao("Iogurtes"));
            preferencias[preferencias.Count - 1].Ativo = true;
            preferencias.Add(new Restricao("Legumes"));
            preferencias[preferencias.Count - 1].Ativo = true;
            preferencias.Add(new Restricao("Leite"));
            preferencias[preferencias.Count - 1].Ativo = true;
            preferencias.Add(new Restricao("Massas"));
            preferencias[preferencias.Count - 1].Ativo = true;
            preferencias.Add(new Restricao("Ovos"));
            preferencias[preferencias.Count - 1].Ativo = true;
            preferencias.Add(new Restricao("Pães"));
            preferencias[preferencias.Count - 1].Ativo = true;
            preferencias.Add(new Restricao("Peixes"));
            preferencias[preferencias.Count - 1].Ativo = true;
            preferencias.Add(new Restricao("Sucos"));
            preferencias[preferencias.Count - 1].Ativo = true;

            return preferencias;
        }
    }
}
