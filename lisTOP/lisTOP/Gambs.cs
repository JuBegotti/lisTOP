using System;
using System.Collections.Generic;
using System.Text;

namespace lisTOP
{
    class Gambs
    {
        public static List<Restricao> preferencias = Restricao.PegarTodasPreferencias();
        public static List<Restricao> restricoes = Restricao.PegarTodasRestricoes();
        public static OpcoesLista listaAtual = new OpcoesLista();
        public static String nomeAtual = "";
        public static Lista listaEdicao = new Lista();
        public static List<Lista> listas = App.DAUtil.GetAllListas();
        public static List<Usuario> usuarios = App.DAUtil.GetAllUsuarios();
        public static List<Usuario> usuariosLista = new List<Usuario>();
        public static Usuario usuario = new Usuario();
    }
}
