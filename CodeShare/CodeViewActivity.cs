using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
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

        // working.......
        TextView tv_title, tv_link, tv_disc;
        ImageView imageView_screenshot1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_code_view);

            tv_title = FindViewById<TextView>(Resource.Id.textView4);
            tv_link = FindViewById<TextView>(Resource.Id.textView5);
            tv_disc = FindViewById<TextView>(Resource.Id.textView6);
            imageView_screenshot1 = FindViewById<ImageView>(Resource.Id.imageView_screenshot1);

            string code_id_intent = Intent.GetStringExtra("code_id");
            string title_intent = Intent.GetStringExtra("code_title");
            string code_link_intent = Intent.GetStringExtra("code_link");
            string code_desc_intent = Intent.GetStringExtra("code_desc");
          
           // code_image_intent = (Android.Net.Uri)Intent.GetParcelableExtra(Intent.ExtraStream);

            string image_intent = Intent.GetStringExtra("code_image");

            //Intent intent = new Intent(Intent.ActionOpenDocument);
            //intent.SetType("Image/*");
            //intent.SetData(Android.Net.Uri.Parse( image_intent));
            
            Android.Net.Uri uri;
            uri = Android.Net.Uri.Parse(image_intent);
           

            // code_image_intent = Intent.GetParcelableExtra("code_image");


            //Uri uri = new Uri(code_image_intent);
            //Android.Net.Uri uri = Android.Net.Uri.Parse(Android.Net.Uri.Decode(code_image_intent));

            //Console.WriteLine("String to URI **********" + uri);

            //Console.WriteLine("code image intent uri .........."+ code_image_intent);

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
            //imageView_screenshot1.SetImageURI(Android.Net.Uri.Parse(image_intent));
            imageView_screenshot1.SetImageURI(uri);



            // Create your application here
        }
    }
}