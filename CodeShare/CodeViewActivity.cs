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
    [Activity(Label = "CodeViewActivity")]
    public class CodeViewActivity : Activity
    {
        TextView tv_title, tv_link, tv_disc;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_code_view);

            tv_title = FindViewById<TextView>(Resource.Id.textView4);
            tv_link = FindViewById<TextView>(Resource.Id.textView5);
            tv_disc = FindViewById<TextView>(Resource.Id.textView6);

            string code_id_intent = Intent.GetStringExtra("code_id");
            string title_intent = Intent.GetStringExtra("code_title");
            string code_link_intent = Intent.GetStringExtra("code_link");
            string code_desc_intent = Intent.GetStringExtra("code_desc");
            
            
            tv_title.Text = title_intent;
            tv_link.Text = code_link_intent;
            tv_disc.Text = code_desc_intent;



            // Create your application here
        }
    }
}