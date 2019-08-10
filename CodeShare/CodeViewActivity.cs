using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CodeShare
{
    [Activity(Label = "CodeViewActivity")]
    public class CodeViewActivity : Activity
    {
        CodeDataModel cdm = new CodeDataModel();
        public static string codeImage = "image";

       // Android.Net.Uri code_image_intent;

        string code_image = "";
        string image_intent;
        Bitmap bitmap;

        // working.......
        TextView tv_title, tv_link, tv_disc;
        ImageView imageView_screenshot1;
        Button btn_save_fav;

       
        string code_id_intent, title_intent, code_link_intent, code_desc_intent, email_intent;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_code_view);



            tv_title = FindViewById<TextView>(Resource.Id.textView4);
            tv_link = FindViewById<TextView>(Resource.Id.textView5);
            tv_disc = FindViewById<TextView>(Resource.Id.textView6);
            imageView_screenshot1 = FindViewById<ImageView>(Resource.Id.imageView_screenshot1);

            btn_save_fav = FindViewById<Button>(Resource.Id.button_fav);



            code_id_intent = Intent.GetStringExtra("code_id");
            title_intent = Intent.GetStringExtra("code_title");
            code_link_intent = Intent.GetStringExtra("code_link");
            code_desc_intent = Intent.GetStringExtra("code_desc");
            email_intent = Intent.GetStringExtra("email");
            image_intent = Intent.GetStringExtra("code_image");

            // code_image_intent = (Android.Net.Uri)Intent.GetParcelableExtra(Intent.ExtraStream);



            // Convert byte[] to bitmap  to show image

            var str = Convert.FromBase64String(image_intent);
                bitmap = BitmapFactory.DecodeByteArray(str, 0, str.Length);
           


            ICursor myresult = cdm.PrintCodeListImage(this, Convert.ToInt32(code_id_intent));

           
            //while (myresult.MoveToNext())
            //{
            //    //myEmail = myresult.GetString(myresult.GetColumnIndexOrThrow(emailValue));
            //    // working code
               
            //    code_image = myresult.GetString(myresult.GetColumnIndexOrThrow(codeImage));

                

            //    //custom Adaptor addition
            //}

            //uri = Android.Net.Uri.Parse(code_image);

            //Intent intent = new Intent();
            //Intent.SetType("image/*");
            //Android.Net.Uri uri = Android.Net.Uri.Parse((code_image));
            // Android.Net.Uri uri;
            // uri = Intent.Data;
            //uri = Intent.GetStringExtra("code_image");

            tv_title.Text = title_intent;
            tv_link.Text = code_link_intent;
            tv_disc.Text = code_desc_intent;
           
        imageView_screenshot1.SetImageBitmap(bitmap);

            btn_save_fav.Click += Btn_save_fav_Click;



            // Create your application here
        }

        private void Btn_save_fav_Click(object sender, EventArgs e)
        {
            
            cdm.insertValueFav(this, email_intent, title_intent, code_link_intent, code_desc_intent, image_intent);
            new Utils().alertFunction("Added To Favourite", "Click Ok", this);
        }


        //public static readonly int PickImageId = 1000;

        //private void Button_screenshot_add_Click(object sender, EventArgs e)
        //{
        //    Intent = new Intent();
        //    Intent.SetType("image/*");
        //    Intent.SetAction(Intent.ActionGetContent);
        //    StartActivityForResult(Intent.CreateChooser(Intent, "Select Picture"), PickImageId);
        //}

        //protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        //{
        //    if ((requestCode == PickImageId) && (resultCode == Result.Ok) && (data != null))
        //    {

        //        Android.Net.Uri uri = this.uri;

        //        imageView_screenshot1.SetImageURI(Android.Net.Uri.Parse(Android.Net.Uri.Decode( image_intent)));


        //    }
        //}
    }
}