using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(lisTOP.Droid.SQLiteService))]
namespace lisTOP.Droid
{
    class SQLiteService : ISQLite
    {
        public SQLiteService() { }

        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "listop.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);

            if (!File.Exists(path))
            {
                var s = Forms.Context.Resources.OpenRawResource(Resource.Raw.listop);
                FileStream writeStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);

                ReadWriteStream(s, writeStream);
            }

            return new SQLiteConnection(path);
        }

        void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            int Length = 256;
            Byte[] buffer = new Byte[Length];
            int bytesRead = readStream.Read(buffer, 0, Length);
            // write the required bytes
            while (bytesRead != 0)
			{
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, Length);
            }
            readStream.Close();
            writeStream.Close();
        }
    }
}