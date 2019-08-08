using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CodeShare.Models;

namespace CodeShare
{
    [Activity(Label = "SignUpActivity")]
    public class SignUpActivity : Activity
    {
        Button btn_back, btn_sign_up;
        EditText et_email, et_password,et_name,et_age;

        DataConnection myDB;
        UserDataModel udm = new UserDataModel();

        // *** Updated Code ***
        //private UserContext userDB;


        public static string emailValue = "email", nameValue = "name", passwordValue = "password", ageValue = "age";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // *** Updated Code ***
            //userDB = new UserContext(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "code.db3"));


            SetContentView(Resource.Layout.activity_sign_up);
            // Create your application here

            btn_back = FindViewById<Button>(Resource.Id.button_back);
            btn_sign_up = FindViewById<Button>(Resource.Id.button_sign_up);
            et_email = FindViewById<EditText>(Resource.Id.editText_email);
            et_password = FindViewById<EditText>(Resource.Id.editText_password);
            et_name = FindViewById<EditText>(Resource.Id.editText_name);
            et_age = FindViewById<EditText>(Resource.Id.editText_age);


            btn_back.Click += delegate
            {
                Intent homeScreen = new Intent(this, typeof(MainActivity));
                StartActivity(homeScreen);
            };

            btn_sign_up.Click += Btn_sign_up_Click;

        }

        //private void Btn_sign_up_Click(object sender, EventArgs e)
        //{
        //    var user = new User
        //    {
        //        Email = et_email.Text,
        //        Password = et_password.Text,
        //        Name = et_name.Text,
        //        Age = Convert.ToInt32(et_age.Text)

        //    };
        //}


        // Working Code
        private void Btn_sign_up_Click(object sender, EventArgs e)
        {
            var emailValue = et_email.Text;
            var passwordValue = et_password.Text;
            var nameValue = et_name.Text;
            var ageValue = et_age.Text;


            if (emailValue.Trim().Equals("") || emailValue.Length < 0 ||
                passwordValue.Trim().Equals("") || passwordValue.Length < 0 ||
                nameValue.Trim().Equals("") || nameValue.Length < 0 ||
                ageValue.Trim().Equals("") || ageValue.Length < 0)
            {
                new Utils().alertFunction("Error", "Please Complete all the fields", this);

            }
            else
            {
                bool flag = udm.duplicateCheck(this, emailValue, passwordValue);
                if (flag == false)
                {
                    new Utils().alertFunction("Duplicate Value", "Email Already registered", this);
                }
                else
                {
                    udm.insertValue(this, emailValue, passwordValue, nameValue, ageValue);

                    new Utils().alertFunction("Registration Successfull", "Click Ok to Login", this);
                }
            }


        }




    }
}