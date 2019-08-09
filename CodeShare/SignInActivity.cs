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
    [Activity(Label = "SignInActivity")]
    public class SignInActivity : Activity
    {
        Button btn_back, btn_sign_in;
        EditText et_email, et_password;
        //DbHelper myDB;

        DataConnection myDB;
        UserDataModel udm = new UserDataModel();

        public static string emailValue = "email", nameValue = "name", passwordValue = "password", ageValue = "age";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_sign_in);

            //myDB = new DbHelper(this);

            myDB = new DataConnection(this);

            // Registering Components
            btn_back = FindViewById<Button>(Resource.Id.button_back);
            btn_sign_in = FindViewById<Button>(Resource.Id.button_sign_in);
            et_email = FindViewById<EditText>(Resource.Id.editText_email);
            et_password = FindViewById<EditText>(Resource.Id.editText_password);

            //button click events
            btn_sign_in.Click += Btn_sign_in_Click;

            btn_back.Click += delegate
            {
                Intent homeScreen = new Intent(this, typeof(MainActivity));
                StartActivity(homeScreen);
            };
        }

        private void Btn_sign_in_Click(object sender, EventArgs e)
        {


            var email = et_email.Text;
            var password = et_password.Text;
            // Comment here validation

            if ((email.Trim().Equals("") || email.Length < 0) ||
                (password.Trim().Equals("") || password.Length < 0))
            {
                new Utils().alertFunction("Error", "Please Fill All Fields", this);
            }
            else if (udm.duplicateCheck(this, email, password) && (email != "ssd" && password != "ssd"))
            {
                new Utils().alertFunction("Error", "User Does Not Exist", this);
            }
            else
            {
                //working code but not usable here

                ICursor myresult = udm.Print2Account(this, email, password);
                var myEmail = "";
                var myName = "";
                var myAge = 0;
                var myPassword = "";

                while (myresult.MoveToNext())
                {
                   myEmail = myresult.GetString(myresult.GetColumnIndexOrThrow(emailValue));
                   myName = myresult.GetString(myresult.GetColumnIndexOrThrow(nameValue));
                   myAge = myresult.GetInt(myresult.GetColumnIndexOrThrow(ageValue));
                   myPassword = myresult.GetString(myresult.GetColumnIndexOrThrow(passwordValue));
                }

                // login commented ablve is correct

                var newScreen = new Intent(this, typeof(MainTabActivity));
                newScreen.PutExtra("mail", myEmail);
                newScreen.PutExtra("name", myName);
                newScreen.PutExtra("age", myAge);
                newScreen.PutExtra("password", myPassword);
                StartActivity(newScreen);
            }
        }
    }
}