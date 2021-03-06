﻿using System;
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
    class CodeDataModel
    {
        SQLiteDatabase connectionObj;


        public static string tableNameCode = "Code";
        public static string tableNameCodeFav = "CodeFav";

        // Code Table Content and crete query

        //public static string emailValue="email", titleValue = "title", linkValue = "link", discriptionValue = "discription", image_uri = "image";

        //public string createTableCode = string.Format("Create table {0} ({1} text, {2} text, {3} text, {4} text, {5} text);"
        //    , tableNameCode, emailValue, titleValue, linkValue, discriptionValue, image_uri);


        public string DeleteQuery = "DROP TABLE IF EXISTS " + tableNameCode;

        //Duplicate User check in database while Registering

        //public bool duplicateCheck(Context context, string emailid, string passwordid)
        //{
        //    connectionObj = new DataConnection(context).ReadableDatabase;

        //    bool flag = true;
        //    // {0}tableName {1}emailValue {2} emailid {3} passwordValue (4) passwordid
        //    string checkStm = string.Format("Select * from {0} where {1} = '{2}' and {3} = '{4}' ", tableName, emailValue, emailid, passwordValue, passwordid);

        //    ICursor myresult = connectionObj.RawQuery(checkStm, null);
        //    if (myresult.Count > 0)
        //    {
        //        flag = false;
        //    }
        //    return flag;
        //}

        ////Insert into User table ***Sign up page insert function ***
        //public void insertValue(Context context, string emailValue, string passwordValue, string nameValue, string ageValue)
        //{
        //    string insertStm = string.Format("Insert into {0} values ( '{1}', '{2}', '{3}', {4});",
        //    tableName, emailValue, passwordValue, nameValue, ageValue);

        //    Console.WriteLine("My SQL  Insert STM \n  \n" + insertStm);

        //    connectionObj.ExecSQL(insertStm);

        //}

        // Insert into code Table

        public void insertValue(Context context, string emailValue, string titleValue, string linkValue, string discriptionValue, string image_uri )
        {
            connectionObj = new DataConnection(context).ReadableDatabase;
            string insertStm = string.Format("Insert into {0} ( email, title, link, discription, image ) values ( '{1}', '{2}', '{3}', '{4}', '{5}');"
            , tableNameCode, emailValue, titleValue, linkValue, discriptionValue, image_uri);

            Console.WriteLine("My SQL  Insert STM \n  \n" + insertStm);

            connectionObj.ExecSQL(insertStm);

        }



        //Print All Code List
        public ICursor PrintCodeList(Context context)
        {
            connectionObj = new DataConnection(context).ReadableDatabase;
            string selectCodeStm = string.Format("Select * from {0} ", tableNameCode);

            ICursor myresult = connectionObj.RawQuery(selectCodeStm, null);

            return myresult;
        }
        string emailValue = "email";



        // CodeFav Table Queries

        public void insertValueFav(Context context, string emailValue, string titleValue, string linkValue, string discriptionValue, string image_uri)
        {
            connectionObj = new DataConnection(context).ReadableDatabase;
            string insertStm = string.Format("Insert into {0} ( email, title, link, discription, image ) values ( '{1}', '{2}', '{3}', '{4}', '{5}');"
            , tableNameCodeFav, emailValue, titleValue, linkValue, discriptionValue, image_uri);

            Console.WriteLine("My SQL  Insert STM \n  \n" + insertStm);

            connectionObj.ExecSQL(insertStm);

        }


        public ICursor PrintCodeListMyCodeFav(Context context, string myemail)
        {
            connectionObj = new DataConnection(context).ReadableDatabase;
            string selectCodeStm = string.Format("Select * from {0} where {1} = '{2}' ", tableNameCodeFav, emailValue, myemail);

            ICursor myresult = connectionObj.RawQuery(selectCodeStm, null);

            return myresult;
        }

        //print image

        string codeID = "id";
        public ICursor PrintCodeListImage(Context context, int codeId)
        {
            connectionObj = new DataConnection(context).ReadableDatabase;
            string selectCodeStm = string.Format("Select * from {0} where {1} = {2} ", tableNameCode, codeID, codeId );

            ICursor myresult = connectionObj.RawQuery(selectCodeStm, null);

            return myresult;
        }


        ////Print values from database to account fragment with specific user email
        //public ICursor Print2Account(Context context, string emailid, string passwordid)
        //{
        //    connectionObj = new DataConnection(context).ReadableDatabase;

        //    //{0} tableName, {1} emailValue {2} emailid {3} passwordValue {4} passwordid
        //    string selectStm = string.Format("Select * from {0} where {1} = '{2}' and {3} = '{4}' ", tableName, emailValue, emailid, passwordValue, passwordid);

        //    ICursor myresut = connectionObj.RawQuery(selectStm, null);

        //    return myresut;
        //}


        //My Update Function to update user data
        //public void updateValue(Context context, string password, string name, int age)
        //{
        //    connectionObj = new DataConnection(context).WritableDatabase;
        //    //{0} tableName {1}nameValue {2} nameid {3} ageValue {4}ageid {5} emailValue {6}emailid

        //    string updateStm = string.Format("Update {0} Set {1} = '{2}', {3} = '{4}' where {5} = {6} ", tableName, passwordValue, password, nameValue, name, ageValue, age);
        //    connectionObj.ExecSQL(updateStm);
        //}






    }
}
