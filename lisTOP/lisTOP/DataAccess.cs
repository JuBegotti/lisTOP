using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace lisTOP
{
    public class DataAccess
    {
        SQLiteConnection db;

        public DataAccess()
        {
            //DependencyService.Register<Droid.SQLiteService>();

            db = DependencyService.Get<ISQLite>().GetConnection();
            db.CreateTable<Usuario>();
            db.CreateTable<Lista>();
            db.CreateTable<Item>();
        }

        public List<Usuario> GetAllUsuarios()
        {
            return db.Query<Usuario>("SELECT * FROM [Usuarios]");
        }

        public int AddUsuario(Usuario usuario)
        {
            return db.Insert(usuario);
        }

        public int RemoveUsuario(Usuario usuario)
        {
            return db.Delete(usuario);
        }

        public int UpdateUsuario(Usuario usuario)
        {
            return db.Update(usuario);
        }

        public List<Lista> GetAllListas()
        {
            List<Lista> listas = db.Query<Lista>("SELECT * FROM [Listas]");

            foreach (Lista lista in listas){
                lista.compras = GetAllItems(lista.id);
            }

            return listas;
        }

        public int AddLista(Lista lista)
        {
            int id = db.Insert(lista);
            foreach (Item item in lista.compras)
            {
                item.IdLista = lista.id;
                db.Insert(item);
            }
            Gambs.listas = GetAllListas();
            return id;
        }

        public int RemoveLista(Lista lista)
        {
            this.RemoveAllItems(lista.id);
            Gambs.listas = GetAllListas();
            return db.Delete(lista);
        }

        public int UpdateLista(Lista lista)
        {
            this.RemoveAllItems(lista.id);
            foreach (Item item in lista.compras)
            {
                db.Insert(item);
            }

            Gambs.listas = GetAllListas();

            return db.Update(lista);
        }

        public List<Item> GetAllItems(Int32 IdLista)
        {
            return db.Query<Item>("SELECT * FROM [Items] Where IdLista = " + IdLista);
        }

        public int AddItem(Item item)
        {
            return db.Insert(item);
        }

        public int RemoveItem(Item item)
        {
            return db.Delete(item);
        }

        public int RemoveAllItems(Int32 IdLista)
        {
            return db.Execute("DELETE FROM [Items] WHERE IdLista = " + IdLista);
        }

        public int UpdateItem(Item item)
        {
            return db.Update(item);
        }

        public List<Alimento> GetAllAlimentos()
        {
            return db.Query<Alimento>("SELECT * FROM [Alimentos]");
        }

        public List<Alimento> GetAllAlimentos(Int32 id)
        {
            return db.Query<Alimento>("SELECT * FROM [Alimentos] WHERE Id = " + id);
        }

        public List<Alimento> GetAllAlimentos(String Where)
        {
            return db.Query<Alimento>("SELECT * FROM [Alimentos] " + Where);
        }

        public List<Alimento> GetAllAlimentosCafe()
        {
            return db.Query<Alimento>("SELECT * FROM [Alimentos] WHERE TipoRefeicao = 'café da manhã'");
        }

        public List<Alimento> GetAllAlimentosAlmocoJanta()
        {
            return db.Query<Alimento>("SELECT * FROM [Alimentos] WHERE TipoRefeicao <> 'café da manhã'");
        }
    }
}
