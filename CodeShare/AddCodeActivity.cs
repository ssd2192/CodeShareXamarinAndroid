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

namespace CodeShare
{
    [Activity(Label = "AddCodeActivity")]
    public class AddCodeActivity : Activity
    {
        EditText editText_title_add, editText_link_add, editText_disc_add;
        Button button_insert_code;

        string emailFromMaintab;

        DataConnection myDB;

        CodeDataModel cdm = new CodeDataModel();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_add_code);

            editText_title_add = FindViewById<EditText>(Resource.Id.editText_title_add) ;
            editText_link_add = FindViewById<EditText>(Resource.Id.editText_link_add);
            editText_disc_add = FindViewById<EditText>(Resource.Id.editText_disc_add);

            emailFromMaintab = Intent.GetStringExtra("mail");

            button_insert_code = FindViewById<Button>(Resource.Id.button_insert_code);

            button_insert_code.Click += Button_insert_code_Click;

        }

        private void Button_insert_code_Click(object sender, EventArgs e)
        {
            var title = editText_title_add.Text;
            var link = editText_link_add.Text;
            var disc = editText_disc_add.Text;
            if (title.Trim().Equals("") || title.Length < 0 ||
                link.Trim().Equals("") || link.Length < 0 ||
                disc.Trim().Equals("") || disc.Length < 0 )
            {
                new Utils().alertFunction("Error", "Please Complete all the fields", this);
            }
            else{
                //udm.insertValue(this, emailValue, passwordValue, nameValue, ageValue);
                cdm.insertValue(this, emailFromMaintab, title, link, disc);

                new Utils().alertFunction("Code Added Successfull", "Click Ok to Login", this);

            }
        }
    }
}