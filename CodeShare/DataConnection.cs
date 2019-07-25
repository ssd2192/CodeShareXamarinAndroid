using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database.Sqlite;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CodeShare
{
    class DataConnection : SQLiteOpenHelper
    {
        //Context myContex;  // Step 4
        public DataConnection(Context context) : base(context, _DatabaseName, null, 1)
        {
        }

        private static string _DatabaseName = "mydatabase.db";

        UserDataModel udm = new UserDataModel();
        

        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL(udm.createTableUser);
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            db.ExecSQL(udm.DeleteQuery);
            OnCreate(db);
        }
    }
}