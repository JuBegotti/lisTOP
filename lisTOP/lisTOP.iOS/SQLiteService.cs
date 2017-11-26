using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using SQLite;
using UIKit;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(lisTOP.iOS.SQLiteService))]
namespace lisTOP.iOS
{
    class SQLiteService : ISQLite
    {
        public SQLiteService() { }

        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "listop.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);

            // This is where we copy in the prepopulated database
            Console.WriteLine(path);
            if (!File.Exists(path))
            {
                File.Copy(sqliteFilename, path);
            }

            return new SQLiteConnection(path);
        }
    }
}