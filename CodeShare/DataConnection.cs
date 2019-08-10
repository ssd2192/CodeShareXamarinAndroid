using System;
using Android.Content;
using Android.Database.Sqlite;

namespace CodeShare
{
    class DataConnection : SQLiteOpenHelper
    {
        Context myContex;  // Step 4
        SQLiteDatabase connectionObj;

        //UserDataModel udm = new UserDataModel();
        //CodeDataModel cdm = new CodeDataModel();

        public DataConnection(Context context) : base(context, _DatabaseName, null, 1)
        {
           
        }

        private static string _DatabaseName = "mydatabase.db5";
        public static string tableName = "User";
        public static string tableNameCode = "Code";
        public static string tableNameCodeFav = "CodeFav";



        // User Table Content and crete query
        public static string emailValue = "email", nameValue = "name", passwordValue = "password", ageValue = "age";

        public string createTableUser = string.Format("Create table {0} ({1} text Primary Key, {2} text, {3} text, {4} Integer);"
            , tableName, emailValue, passwordValue, nameValue, ageValue);

        public string DeleteQuery = "DROP TABLE IF EXISTS " + tableName;

        // Code Table Content and create query

        public static string codeID = "id", titleValue = "title", linkValue = "link", discriptionValue = "discription", image_uri = "image";

        public string createTableCode = string.Format("Create table {0} ({1} Integer Primary Key  Autoincrement, {2} text, {3} text, {4} text, {5} text, {6} text);"
            , tableNameCode, codeID, emailValue, titleValue, linkValue, discriptionValue, image_uri);


        public string DeleteQueryCode = "DROP TABLE IF EXISTS " + tableNameCode;


        // Code Table Content and create query

       // public static string codeID = "id", titleValue = "title", linkValue = "link", discriptionValue = "discription", image_uri = "image";

        public string createTableCodeFav = string.Format("Create table {0} ({1} Integer Primary Key  Autoincrement, {2} text, {3} text, {4} text, {5} text, {6} text);"
            , tableNameCodeFav, codeID, emailValue, titleValue, linkValue, discriptionValue, image_uri);

        
        public string DeleteQueryCodeFav = "DROP TABLE IF EXISTS " + tableNameCodeFav;


        public override void OnCreate(SQLiteDatabase db)
        {
            // Test
            Console.WriteLine("Inside create table dataconnection");
            db.ExecSQL(createTableCode);
            db.ExecSQL(createTableUser);
            db.ExecSQL(createTableCodeFav);
           //db.ExecSQL(cdm.createTableCode);
            
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            db.ExecSQL(DeleteQuery);
            db.ExecSQL(DeleteQueryCode);
            db.ExecSQL(DeleteQueryCodeFav);
            OnCreate(db);
        }
    }
}