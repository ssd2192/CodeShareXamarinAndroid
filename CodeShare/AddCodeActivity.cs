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
        Button button_screenshot_add, button_insert_code;
        ImageView imageView_screen;

        string emailFromMaintab;

        Android.Net.Uri uri;

        DataConnection myDB;

        CodeDataModel cdm = new CodeDataModel();

        public static readonly int PickImageId = 1000;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_add_code);

            editText_title_add = FindViewById<EditText>(Resource.Id.editText_title_add) ;
            editText_link_add = FindViewById<EditText>(Resource.Id.editText_link_add);
            editText_disc_add = FindViewById<EditText>(Resource.Id.editText_disc_add);
            imageView_screen = FindViewById<ImageView>(Resource.Id.imageView_screen);

            emailFromMaintab = Intent.GetStringExtra("mail");
            button_screenshot_add = FindViewById<Button>(Resource.Id.button_screenshot_add);
            button_insert_code = FindViewById<Button>(Resource.Id.button_insert_code);

            button_screenshot_add.Click += Button_screenshot_add_Click;
            button_insert_code.Click += Button_insert_code_Click;

        }


        // Add ScreenShots Button ***************************
        private void Button_screenshot_add_Click(object sender, EventArgs e)
        {
            Intent = new Intent();
            Intent.SetType("image/*");
            Intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(Intent, "Select Picture"), PickImageId);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if ((requestCode == PickImageId) && (resultCode == Result.Ok) && (data != null))
            {
                uri = data.Data;
                imageView_screen.SetImageURI(uri);

                Console.WriteLine("Uri to String********** " + Convert.ToString(uri));
                Console.WriteLine("URI *****" + uri);
            }
        }

            //End Add ScreenShots Button ***************************


            // Button to insrt Code 
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
                cdm.insertValue(this, emailFromMaintab, title, link, disc, Convert.ToString(uri));

                new Utils().alertFunction("Code Added Successfull", "Click Ok to Login", this);

            }
        }
    }
}