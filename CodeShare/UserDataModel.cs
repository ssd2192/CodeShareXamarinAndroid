using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.Database.Sqlite;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CodeShare
{
    class UserDataModel
    {
        SQLiteDatabase connectionObj;


        public static string tableName = "User";
        public string nameFiled = "names";
        public string id = "id";

        // User Table Content and crete query
        public static string emailValue = "email", nameValue = "name", passwordValue = "password", ageValue = "age";

        public string createTableUser = string.Format("Create table {0} ({1} text Primary Key, {2} text, {3} text, {4} Integer)"
            , tableName, emailValue, passwordValue, nameValue, ageValue);

        public string DeleteQuery = "DROP TABLE IF EXISTS " + tableName;

        //Duplicate User check in database while Registering

        public bool duplicateCheck(Context context, string emailid, string passwordid)
        {
            connectionObj = new DataConnection(context).ReadableDatabase;

            bool flag = true;
            // {0}tableName {1}emailValue {2} emailid {3} passwordValue (4) passwordid
            string checkStm = string.Format("Select * from {0} where {1} = '{2}' and {3} = '{4}' ", tableName, emailValue, emailid, passwordValue, passwordid);

            ICursor myresult = connectionObj.RawQuery(checkStm, null);
            if (myresult.Count > 0)
            {
                flag = false;
            }
            return flag;
        }

        public void insertValue(Context context, string emailValue, string passwordValue, string nameValue, string ageValue)
        {
            string insertStm = string.Format("Insert into {0} values ( '{1}', '{2}', '{3}', {4});",
            tableName, emailValue, passwordValue, nameValue, ageValue);

            Console.WriteLine("My SQL  Insert STM \n  \n" + insertStm);

            connectionObj.ExecSQL(insertStm);

        }



        public ICursor Print2Welcome(Context context ,string emailid, string passwordid)
        {
            connectionObj  = new DataConnection(context).ReadableDatabase;

            //{0} tableName, {1} emailValue {2} emailid {3} passwordValue {4} passwordid
            string selectStm = string.Format("Select * from {0} where {1} = '{2}' and {3} = '{4}' ", tableName, emailValue, emailid, passwordValue, passwordid);

            ICursor myresut = connectionObj.RawQuery(selectStm, null);

            return myresut;
        }





    }
}