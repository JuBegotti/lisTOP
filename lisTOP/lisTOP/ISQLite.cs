using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace lisTOP
{
    interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
